using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Reload_UI;
    [SerializeField] GameObject Planet;
    [SerializeField] GameObject Planet_img;
    [SerializeField] GameObject Satellite_obj;
    [SerializeField] TMP_InputField Satellite_speed;
    [SerializeField] TMP_InputField Satellite_mass;



    Gravity Gravity;
    Satellite satellite_sc;

    Rigidbody2D Satellite_rb;
    Rigidbody2D Planet_rb;

    int planet_mass;
    int satellite_mass;
    int satellite_speed;

    private void Start()
    {
        Planet_rb = Planet.GetComponent<Rigidbody2D>();
        Satellite_rb = Satellite_obj.GetComponent<Rigidbody2D>();

        Gravity = Planet.GetComponent<Gravity>();
        satellite_sc = Satellite_obj.GetComponent<Satellite>();
    }




    public void OnSatellite_massChange(string mass)
    {

        int.TryParse(Satellite_mass.text, out int satellite_mass_1);
        satellite_mass = satellite_mass_1;

        if (Satellite_mass.text == null)
        {
            Debug.Log("satellite_mass");
            Debug.Log(satellite_mass);
            satellite_mass = 84;
        }
    }

    public void OnSatellite_speedChange(string speed)
    {

        
        int.TryParse(Satellite_speed.text, out int satellite_speed_1);
        
        satellite_speed = satellite_speed_1;
        Debug.Log(satellite_speed);
    }

    public void OnChangeValues()
    {
        
        

        SpeedChange(satellite_speed);

        UI.SetActive(false);
        Planet_img.SetActive(true);
        Reload_UI.SetActive(true);
    }
    public void SceneReloading()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SpeedChange(int speed)
    {
        Debug.Log(speed);
        Satellite_obj.SetActive(true);

        Gravity.do_force = true;
        float.TryParse(speed.ToString(), out float s);
        float f = s / 1.6f;
        Debug.Log(f);
        
        float.TryParse(satellite_mass.ToString(), out float m);
        m = m / 84.0f;
        satellite_sc.ConvertForce(f, m);
    }

}
