using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zona : MonoBehaviour
{
    public Transform t;
    public CtrScene cs;

    void Start()
    {
        t = GetComponent<Transform>();     
    }


    // Update is called once per frame

    void OnMouseDown()
    {
        //Instantiate(sound);
        cs.VolverMenu();

    }

}
