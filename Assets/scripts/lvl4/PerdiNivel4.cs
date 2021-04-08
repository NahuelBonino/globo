using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdiNivel4 : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Crtl_Objetivos_lvl4 ctrl4;    
    
    void Start()
    {
        ctrl4 = GameObject.Find("CtrlObjetivo").GetComponent(typeof(Crtl_Objetivos_lvl4)) as Crtl_Objetivos_lvl4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){       
        ctrl4.Fail();
    }


}
