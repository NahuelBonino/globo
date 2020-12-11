﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Crtl_Objetivos_lvl2 : MonoBehaviour
{
    public Canvas obj1;

    private float contador_descuento;
    private static Crtl_Objetivos_lvl2 instance;

    private float tiempo_lim_obj1;
    public static Text tiempo_limite;
    public static Text puntaje_total;
    public static Text  tmp_limite_show;
    public static CtrScene ctr;
    public int currentObj;
    private globo_spawn_lvl2 spawner;
    public int Puntaje_t;
    public float contador_velocidad;
    public Button boton_siguiente_lvl;
    public float tiempo_entre_globos;
    public float contador_tiempo_entre_globos;
    public float velocidadobjetivo;
    void Awake()
    {

        if (instance == null)
        {

            instance = this;
           // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
        ctr = GameObject.Find("CtrScene").GetComponent (typeof(CtrScene)) as CtrScene;
       
        //tiempo_limite =  GameObject.Find("tiempo_limite").GetComponent(typeof(Text)) as Text;
        
        spawner =  GameObject.Find("spawner").GetComponent(typeof(globo_spawn_lvl2)) as globo_spawn_lvl2;
        spawner.SetVelocidadGlobo(velocidadobjetivo);

        puntaje_total = GameObject.Find("puntajeTotal").GetComponent(typeof(Text)) as Text;

        tmp_limite_show = GameObject.Find("tmp_limite").GetComponent(typeof(Text)) as Text;

        

       
        
    }

    void Start()
    {       
        Instantiate(obj1); //INSTANCIO AL PRINCIPIO EL OBJETIVO 1
       // Puntaje_rojo = 0;
       // Puntaje_violeta = 0;
        currentObj = 1; // OBJETIVO ACTUAL 1
        //contador_obj2 = 0;
        tiempo_lim_obj1 = 10.0f; // TIEMPO LIMITE DEL OBJETIVO 2
        Puntaje_t = 0;
        contador_velocidad = 0f;
        velocidadobjetivo = 1.0f;
        tmp_limite_show.text = tmp_limite_show.ToString();
        tiempo_entre_globos = 2.0f;
       // Puntos_obj_1 = 15; //PUNTOS DEL OBJETIVO1
       // iluminacionActual = 0;
       // iluminacion_objetivo = 25;
        boton_siguiente_lvl.interactable = false;
        boton_siguiente_lvl.GetComponent<Image>().color = new Color32(255,255,255,0);
        
    }

    public static Crtl_Objetivos_lvl2 getInstance()
    {
        return instance;
    }
   
    private void Update()
    {
            //BAJO EL CONTADOR DEL OBJETIVO 2
      
            tiempo_lim_obj1  -=  Time.deltaTime;
           
            contador_descuento += Time.deltaTime;
                                    
            contador_velocidad = contador_velocidad + Time.deltaTime;

            contador_tiempo_entre_globos = contador_velocidad + Time.deltaTime;

            if(tmp_limite_show != null)
               tmp_limite_show.text = Math.Round(tiempo_lim_obj1).ToString();

            if(contador_velocidad >= 5.0f){

              velocidadobjetivo = velocidadobjetivo + 0.05f;  
           
              spawner.SetVelocidadGlobo(velocidadobjetivo);
           
              contador_velocidad = 0f;
             }
             
            if(contador_tiempo_entre_globos >= 10.0f){

              tiempo_entre_globos = tiempo_entre_globos - 0.1f;  
           
              spawner.setTiempoEntreGlobos(tiempo_entre_globos);
           
              contador_tiempo_entre_globos = 0f;
             }

                if (tiempo_lim_obj1 <= 0)  //CUMPLO OBJETIVO 
              {
                 boton_siguiente_lvl.interactable = true;
                 boton_siguiente_lvl.GetComponent<Image>().color = new Color32(255,255,255,255);     //Instanciar el boton (ir a menu)
                 Destroy(tmp_limite_show);   //sacar el contador
               }


    }


    public int getCurrentObj()
    {
        return currentObj;
    }

    public void incrementarPuntaje(string type_globo)
    {
        
    if(currentObj == 1){ //OBJETIVO  EXPLOTAR TODOS.
     
        Puntaje_t++;
        puntaje_total.text = Puntaje_t.ToString();  
     

    } //FIN OBJETIVO 1
     
  }

   private void pararSpawn(){  //le digo 
        spawner.stopSpawnforMoment();
    }


    public void Fail(){ //PERDI EL JUEGO
 

    }


}