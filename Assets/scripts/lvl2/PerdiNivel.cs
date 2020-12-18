using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdiNivel : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Crtl_Objetivos_lvl2 ctrl2;    
    
    void Start()
    {
        ctrl2 = GameObject.Find("CtrlObjetivo").GetComponent(typeof(Crtl_Objetivos_lvl2)) as Crtl_Objetivos_lvl2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
        
        ctrl2.Fail();
    }


}
