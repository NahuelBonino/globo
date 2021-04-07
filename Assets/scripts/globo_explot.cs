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


    void OnMouseDown()
    {
        if (lvl==1){
        Crtl_Objetivos_lvl1.getInstance().incrementarPuntaje(gameObject.name);
            explot();
        }
        else if (lvl==2){
            explot();
        }

    }

    public void setLvl(int l){

        lvl = l;

    }

    public void explot(){
        Destroy(gameObject);
        Instantiate(sound);
        Quaternion q = new Quaternion();
        Instantiate(exp,t.position,q);
    }
}

