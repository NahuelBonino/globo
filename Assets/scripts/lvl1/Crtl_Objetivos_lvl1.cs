using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Crtl_Objetivos_lvl1 : MonoBehaviour
{
    public  Canvas obj1;
    public  Canvas obj2;
    public Canvas MarcoBarracolores;

    private Image Barracolores;
    private float contador_descuento;
    private static Crtl_Objetivos_lvl1 instance;
    //private float contador_obj2;
    private float tiempo_lim_obj2;
    private int Puntaje_rojo;
    private int Puntaje_violeta;
    private int iluminacionActual;
    private int iluminacion_objetivo;
    public static Text puntaje_rojo;
    public static Text puntaje_violeta;
    public static Text tiempo_limite;
    public static Text iluminacion_obj2;
    public static CtrScene ctr;
    public int currentObj;

    private globo_spawn_lvl1 spawner;

    public globo_move gm; //Script que pone la velocidad del Globo.

    public int Puntos_obj_1;
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
        puntaje_rojo = GameObject.Find("puntaje_rojo").GetComponent(typeof(Text)) as Text;
        puntaje_violeta = GameObject.Find("puntaje_violeta").GetComponent(typeof(Text)) as Text;
        tiempo_limite =  GameObject.Find("tiempo_limite").GetComponent(typeof(Text)) as Text;
        spawner =  GameObject.Find("spawner").GetComponent(typeof(globo_spawn_lvl1)) as globo_spawn_lvl1;
        
    }

    void Start()
    {       
        Instantiate(obj1); //INSTANCIO AL PRINCIPIO EL OBJETIVO 1
        Puntaje_rojo = 0;
        Puntaje_violeta = 0;
        currentObj = 1; // OBJETIVO ACTUAL 1
        //contador_obj2 = 0;
        tiempo_lim_obj2 = 30.0f; // TIEMPO LIMITE DEL OBJETIVO 2
        Puntos_obj_1 = 15; //PUNTOS DEL OBJETIVO1
        iluminacionActual = 0;
        iluminacion_objetivo = 25;
      
    }

    public static Crtl_Objetivos_lvl1 getInstance()
    {
        return instance;
    }
   
    private void Update()
    {
        if(currentObj == 2){ //BAJO EL CONTADOR DEL OBJETIVO 2
            //CONTADOR GLOBAL DEL OBJETIVO 2
            tiempo_lim_obj2  -=  Time.deltaTime;
            tiempo_limite.text = Math.Round(tiempo_lim_obj2).ToString();
           //CONTADOR DE DESCUENTO OBJETIVO 2
            contador_descuento += Time.deltaTime;
      
            if(contador_descuento >= 0.7f && iluminacionActual>0){
                contador_descuento = 0;
                iluminacionActual--; 
                //iluminacion_obj2.text = iluminacionActual.ToString();
                Barracolores.gameObject.GetComponent<Scrollbar>().size = iluminacionActual/25.0f;
               //cambiar Barra Iluminacion           
            }
        
             if (tiempo_lim_obj2<=0){ //PERDI :C

               ctr.VolverMenu();

            }
        
        
        }
    
    }


    public int getCurrentObj()
    {
        return currentObj;
    }

    public void incrementarPuntaje(string type_globo)
    {
        
    if(currentObj == 1){ //OBJETIVO 1

        if (type_globo.Contains("2")) { //SE EXPLOTO UN GLOBO ROJO
             if (Puntaje_rojo<Puntos_obj_1){
                Puntaje_rojo++;
             }
             else{

                 Puntaje_rojo--;
             }
        }
        else if (type_globo.Contains("4")) { // SE EXPLOTO UN GLOBO VIOLETA
             if (Puntaje_violeta<Puntos_obj_1){
                 Puntaje_violeta++;
             }
             else{

                Puntaje_violeta--;            
            }
        }
        puntaje_rojo.text = Puntaje_rojo.ToString();
        puntaje_violeta.text = Puntaje_violeta.ToString();
        if (Puntaje_violeta == Puntos_obj_1 && Puntaje_rojo == Puntos_obj_1)  //CUMPLO OBJETIVO 1
        {
            spawner.SetVelocidadGlobo(2.8f); // pongo la velocidad nueva de los globos 
            Puntaje_violeta = 0; //saco los puntajes
            Puntaje_rojo = 0;           
            currentObj = 2;  
            Instantiate(obj2); //instancio objetivo 2
            Instantiate(MarcoBarracolores);
            pararSpawn();
            Barracolores = GameObject.Find("scroll").GetComponent(typeof(Image)) as Image; //barra de colores
            Barracolores.gameObject.GetComponent<Scrollbar>().size = 0; //barra de colores inicializada
            puntaje_rojo.gameObject.SetActive(false);
            puntaje_violeta.gameObject.SetActive(false);
            
        }

    }

    else if (currentObj == 2){ //OBJETIVO 2
         
         iluminacionActual++; // INCREMENTO LA ILUMINACION
         //iluminacion_obj2.text = iluminacionActual.ToString(); //MUESTRO LA ILUMINACION ACTUAL
         Barracolores.gameObject.GetComponent<Scrollbar>().size = iluminacionActual/25.0f;
         //print(Barracolores.gameObject.GetComponent<Scrollbar>().size);
         if(iluminacionActual>=iluminacion_objetivo){ //GANEEEE!
                ctr.desbloquearNivel();         
         }

     }
     
  }

   private void pararSpawn(){  //le digo 
        spawner.stopSpawnforMoment();
    }


}
