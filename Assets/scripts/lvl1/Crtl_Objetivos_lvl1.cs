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
    public Image globito_rojo;
    public Image globito_violeta;
    private Image Barracolores;
    private float contador_descuento;
    public Image reloj;
    public Image tiempo;
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
    public bool primer_globo_explotado;
    private bool instanciaron_artilujios_obj2;
    private bool fin_juego = false;
    private globo_spawn_lvl1 spawner;
    private Canvas objBarra;
    public int Puntos_obj_1;
    void Awake()
    {

        if (instance == null)
        {

            instance = this;
           // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code
            ctr = GameObject.Find("CtrScene").GetComponent (typeof(CtrScene)) as CtrScene;
            puntaje_rojo = GameObject.Find("puntaje_rojo").GetComponent(typeof(Text)) as Text;
            puntaje_violeta = GameObject.Find("puntaje_violeta").GetComponent(typeof(Text)) as Text;
            globito_rojo = GameObject.Find("rojo").GetComponent(typeof(Image)) as Image;
            globito_violeta = GameObject.Find("violeta").GetComponent(typeof(Image)) as Image;
            tiempo_limite =  GameObject.Find("tiempo_limite").GetComponent(typeof(Text)) as Text;
            spawner =  GameObject.Find("spawner").GetComponent(typeof(globo_spawn_lvl1)) as globo_spawn_lvl1;

        }
        else
        {
            Destroy(this);
        }

        
    }

    void Start()
    {   
        //espero a que termine la transicion
        Invoke("InstanceObjetivo1",1.3f);         
        Puntaje_rojo = 0;
        Puntaje_violeta = 0;
        currentObj = 1; // OBJETIVO ACTUAL 1
        //contador_obj2 = 0;
        tiempo_lim_obj2 = 40.0f; // TIEMPO LIMITE DEL OBJETIVO 2
        Puntos_obj_1 = 15; //PUNTOS DEL OBJETIVO1
        iluminacionActual = 0;
        iluminacion_objetivo = 5;
        primer_globo_explotado = false;
        instanciaron_artilujios_obj2 = false;
    }

    void InstanceObjetivo1(){

        Instantiate(obj1); //INSTANCIO AL PRINCIPIO EL OBJETIVO 1

    }

    public static Crtl_Objetivos_lvl1 getInstance()
    {
        return instance;
    }
   
    private void Update()
    {
        if(currentObj == 2){ //BAJO EL CONTADOR DEL OBJETIVO 2
            //CONTADOR GLOBAL DEL OBJETIVO 2
            if (instanciaron_artilujios_obj2){
                tiempo_lim_obj2  -=  Time.deltaTime;
                tiempo_limite.text = Math.Round(tiempo_lim_obj2).ToString();
            //CONTADOR DE DESCUENTO OBJETIVO 2
                contador_descuento += Time.deltaTime;
        
                if(contador_descuento >= 0.7f && iluminacionActual>0){
                    contador_descuento = 0;
                    iluminacionActual--; 
                    //iluminacion_obj2.text = iluminacionActual.ToString();
                    if (Barracolores != null){
                    Barracolores.gameObject.GetComponent<Scrollbar>().size = iluminacionActual/25.0f;
                //cambiar Barra Iluminacion           
                    }
                }
            
                if (tiempo_lim_obj2<=0){ //PERDI :C

                    pararSpawn(10);
                    instanciaron_artilujios_obj2 = false;
                  //  Destroy(Barracolores.gameObject); 
                    DestroyImmediate(objBarra.gameObject,true);            
                    reloj.color = new Color(0,0,0,0);
                    tiempo.color = new Color(0,0,0,0);   
                    Invoke("lvlLose",1.0f);

                }    
            }
        }
    
    }


    public int getCurrentObj()
    {
        return currentObj;
    }

    public void incrementarPuntaje(string type_globo)
    {
            if (!primer_globo_explotado){
                globito_rojo.color = new Color(1,1,1);
                globito_violeta.color = new Color(1,1,1);  
                primer_globo_explotado = true;    
            }
                
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
                    pararSpawn(5);
                    puntaje_rojo.gameObject.SetActive(false);
                    puntaje_violeta.gameObject.SetActive(false);
                    globito_rojo.color = new Color(1,1,1,0);       
                    globito_violeta.color = new Color(1,1,1,0); 
                    Instantiate(obj2); //instancio objetivo 2             
                    Invoke("artefactosobj2",3.5f);
                }

            }

            else if (currentObj == 2){ //OBJETIVO 2
                
                iluminacionActual++; // INCREMENTO LA ILUMINACION
                //iluminacion_obj2.text = iluminacionActual.ToString(); //MUESTRO LA ILUMINACION ACTUAL
                if (Barracolores != null){
                Barracolores.gameObject.GetComponent<Scrollbar>().size = iluminacionActual/25.0f;
                }
                //print(Barracolores.gameObject.GetComponent<Scrollbar>().size);
                if(iluminacionActual>=iluminacion_objetivo && !fin_juego){ //GANEEEE!
                    pararSpawn(10);
                   // Destroy(Barracolores.gameObject); 
                    DestroyImmediate(objBarra.gameObject,true);                    
                    reloj.color = new Color(0,0,0,0);
                    tiempo.color = new Color(0,0,0,0); 
                    tiempo_limite.gameObject.SetActive(false); 
                    fin_juego = true;              
                    lvlWin();            
                }
           
            }
            
    }

    private void artefactosobj2(){

        objBarra = Instantiate(MarcoBarracolores);
        Barracolores = GameObject.Find("scroll").GetComponent(typeof(Image)) as Image; //barra de colores
        Barracolores.gameObject.GetComponent<Scrollbar>().size = 0; //barra de colores inicializada
        reloj.color = new Color(1,1,1,1);
        tiempo.color = new Color(1,1,1,1); 
        tiempo.GetComponent<animacionReloj>().ejecutarAnimacion();
        instanciaron_artilujios_obj2 = true;
    }


    private void lvlWin(){

         ctr.desbloquearNivel();

    }
    
    private void lvlLose(){       

         ctr.VolverMenu();

    }


    IEnumerator esperar(int tiempo){
         yield return new WaitForSeconds(tiempo);                 
    }



   private void pararSpawn(int i){  //le digo 
        spawner.stopSpawnforMoment(i);
    }


}
