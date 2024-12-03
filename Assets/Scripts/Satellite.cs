using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Satellite : MonoBehaviour
{
    public float force;
    
    [SerializeField] GameObject Planet;
    [SerializeField] TMP_Text T_text;
    Gravity Gravity;

    public Rigidbody2D rb;
    private void OnSattelite()
    {
        Gravity = Planet.GetComponent<Gravity>();

        rb = GetComponent<Rigidbody2D>();
        findR(force);
        
        Debug.Log(force);
        
        
        rb.AddForce(new Vector3(force, 0, 0), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

        
    }
    public void findR(float v)
    {

        float V = v * 1.6f;
        V = V * 1000;
        float R = (V * V) / 9.8f;
        R = R / 1000;
        T_text.text = R.ToString();
    }
    public void ConvertForce(float speed, float mass)
    {
        Debug.Log(speed);
        
        force = speed;
        
        rb.mass = mass;
        OnSattelite();
    }


  
}
