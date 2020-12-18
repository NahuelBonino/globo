using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class animacionReloj : MonoBehaviour
{
    public Image tiempo;
    public Transform t;
    public Vector3 rotationEuler;
    public float contadorTiempo;
  
    private bool ejecutar;
    void Start()
    {
        ejecutar = false;
    }

    // Update is called once per frame

    public void ejecutarAnimacion(){

        ejecutar = true;

    }
    void Update()
    {

        if (ejecutar){

            rotationEuler -= Vector3.forward*60*Time.deltaTime; //increment 30 degrees every second
            transform.rotation = Quaternion.Euler(rotationEuler);
            //To convert Quaternion -> Euler, use eulerAngles

        }
     }


}
