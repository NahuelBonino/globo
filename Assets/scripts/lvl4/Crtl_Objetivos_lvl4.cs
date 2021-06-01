using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Crtl_Objetivos_lvl4 : MonoBehaviour
{
    public Canvas obj1;

    private float contador_descuento;
    private static Crtl_Objetivos_lvl4 instance;
    public float tiempo_lim_obj1;
    public static Text tiempo_limite;
    public static Text  tmp_limite_show;
    public static CtrScene ctr;
    public int currentObj;
    private globo_spawn_lvl4 spawner;
    public int Puntaje_t;
    public float contador_velocidad;
    public float tiempo_entre_globos;
    public float contador_tiempo_entre_globos;
    public float velocidadobjetivo;
    private bool fin_juego;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
           // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code
             ctr = GameObject.Find("CtrScene").GetComponent (typeof(CtrScene)) as CtrScene;     
             spawner =  GameObject.Find("spawner").GetComponent(typeof(globo_spawn_lvl4)) as globo_spawn_lvl4;
             spawner.SetVelocidadGlobo(velocidadobjetivo);     
        

        }
        else
        {
            Destroy(this);
        }

    }

    void Start()
    {       
      //  Instantiate(obj1); //INSTANCIO AL PRINCIPIO EL OBJETIVO 1
        currentObj = 1; // OBJETIVO ACTUAL 1
        tiempo_lim_obj1 = 150.0f; // TIEMPO LIMITE DEL OBJETIVO 2
        contador_velocidad = 0f;
        velocidadobjetivo = 1.3f;
        //tmp_limite_show.text = tmp_limite_show.ToString();
        tiempo_entre_globos = 2.0f;
        fin_juego = false;
    }

    public static Crtl_Objetivos_lvl4 getInstance()
    {
        return instance;
    }
   
    private void Update()
    {
            //BAJO EL CONTADOR DEL OBJETIVO 2
          
         /*   tiempo_lim_obj1  -=  Time.deltaTime;
           
            contador_descuento += Time.deltaTime;
                                    
            contador_velocidad += Time.deltaTime;

            contador_tiempo_entre_globos = contador_tiempo_entre_globos + Time.deltaTime;

            if(tmp_limite_show != null)
               tmp_limite_show.text = Math.Round(tiempo_lim_obj1).ToString();

            if(contador_velocidad >= 3.0f){

              velocidadobjetivo = velocidadobjetivo + 0.08f;   //VELOCIDAD DE LOS GLOBOS
           
              spawner.SetVelocidadGlobo(velocidadobjetivo);
           
              contador_velocidad = 0f;
             }
             
            if(contador_tiempo_entre_globos >= 10.0f){

              tiempo_entre_globos = tiempo_entre_globos - 0.12f;  //CANTIDAD DE GLOBOS
           
             // Debug.Log("tiempo entre globos " + tiempo_entre_globos.ToString());
              
              spawner.setTiempoEntreGlobos(tiempo_entre_globos);
           
              contador_tiempo_entre_globos = 0f;
             }

                if (tiempo_lim_obj1 <= 0 && !fin_juego)  //GANE!
              {
                  pararSpawn(10);
                  ctr.desbloquearNivel();  
                  fin_juego = true; 
               
              }

*/
    }


    public int getCurrentObj()
    {
        return currentObj;
    }

   private void pararSpawn(int i){  
        spawner.stopSpawnforMoment(i);
    }


    public void Fail(){ //PERDI EL JUEGO
 
        ctr.VolverMenu();

    }


}
