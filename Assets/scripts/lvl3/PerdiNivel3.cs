using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdiNivel3 : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Crtl_Objetivos_lvl3 ctrl3;    
    
    void Start()
    {
        ctrl3 = GameObject.Find("CtrlObjetivo").GetComponent(typeof(Crtl_Objetivos_lvl3)) as Crtl_Objetivos_lvl3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){       
        ctrl3.Fail();
    }


}
