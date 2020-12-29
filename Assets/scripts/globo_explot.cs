using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class globo_explot : MonoBehaviour
{
    public Transform t;
    public GameObject sound;
    public GameObject exp;
    public int lvl;

    void Start()
    {
        t = GetComponent<Transform>(); 
       
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (lvl==1){
        Destroy(gameObject);
        Crtl_Objetivos_lvl1.getInstance().incrementarPuntaje(gameObject.name);
        Instantiate(sound);
        Quaternion q = new Quaternion();
        Instantiate(exp,t.position,q);
        }
        else if (lvl==2){
        Destroy(gameObject);
        Instantiate(sound);
        Quaternion q = new Quaternion();
        Instantiate(exp,t.position,q);
        }


    }

    public void setLvl(int l){

        lvl = l;

    }
}

