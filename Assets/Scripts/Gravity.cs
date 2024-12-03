using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    static float G;

    [SerializeField] GameObject attracted;
    [SerializeField] GameObject attractor;
    public Rigidbody2D attracred_rb;
    public Rigidbody2D attractor_rb;

    [SerializeField] float g = 9.8f;

    public bool do_force = false;
    void Start()
    {
        attracred_rb = attracted.GetComponent<Rigidbody2D>();
        attractor_rb = attractor.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(attractor_rb.mass);
        G = g;
        if (do_force)
        {
            AddGravityForce(attractor_rb, attracred_rb);
        }
        
        
            
    }

    public static void AddGravityForce(Rigidbody2D attractor, Rigidbody2D target)
    {
        float massProduct = attractor.mass * target.mass * G;

        //You could also do
        //float distance = Vector3.Distance(attractor.position,target.position.
        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude; // r = Mathf.Sqrt((x*x)+(y*y))

        //F = G * ((m1*m2)/r^2)
        float unScaledforceMagnitude = massProduct / Mathf.Pow(distance, 2);
        float forceMagnitude = G * unScaledforceMagnitude;

        Vector3 forceDirection = difference.normalized;

        Vector3 forceVector = forceDirection * forceMagnitude;

        target.AddForce(forceVector);
    }


}
