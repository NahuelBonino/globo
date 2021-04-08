using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globo_spawn_lvl2 : MonoBehaviour
{
    public GameObject[] globosObj1;  
    public GameObject globo_especial;
    public int cant_globosObj1;
    float Ran;
    float cont_normal;
    float cont_especial;
    float contador_nivel;
    float contador_esperar;
    float velocidadGlobosp;
    float tiempomuerto;
    bool inst_globo_esp;

    public float tiempo_entre_globo;
    
    
    bool parar;
    void Start()
    {
        inst_globo_esp = false;
        cont_normal = 0f;
        parar = true; 
        velocidadGlobosp = 1.3f;  
        tiempo_entre_globo = 2.0f;
        tiempomuerto = 0;
    }

    // Update is called once per frame
    public void setTiempoEntreGlobos(float tiempo){      
        tiempo_entre_globo = tiempo;
    }
    
    public void stopSpawnforMoment(int t){
      tiempomuerto = t;
      parar = true;
    }
    public void SetVelocidadGlobo(float velocidad){

        velocidadGlobosp = velocidad;
    }

    IEnumerator stopReallySpawn(){       
         yield return new WaitForSeconds (tiempomuerto);    
         parar = false;
    }


    void Update()
    {        
       if (!parar){

           cont_normal += Time.deltaTime;
           cont_especial = cont_especial + Time.deltaTime;
           if(Crtl_Objetivos_lvl2.getInstance().getCurrentObj()==1){ // Globos del objetivo 1
                    
                if (cont_normal >= tiempo_entre_globo){ //INSTANCIO EL GLOBO Y TODO LO REFERIDO
                    Debug.Log("tiempo entre globos " + tiempo_entre_globo.ToString());
                    Ran = Random.Range(-2.7f, 2.7f);
                    int Ran2 = Random.Range(0,cant_globosObj1);
                    Quaternion q = new Quaternion();
                    GameObject globo = Instantiate(globosObj1[Ran2],new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                    globo_explot ge = globo.GetComponent(typeof(globo_explot)) as globo_explot;
                    ge.setLvl(2); //le aviso que es el nivel 2
                    globo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocidadGlobosp),UnityEngine.ForceMode2D.Impulse); //instancio y agrego velocidad
                    cont_normal = 0f;
                    globo.GetComponent<BoxCollider2D>().isTrigger = true;
                }
                
            }           
                if (cont_especial >= 15.0f && inst_globo_esp){ //GLOBO ESPECIAL (EXPLOSION MULTIPLE)
                    Ran = Random.Range(-2f, 2f);               
                    Quaternion q = new Quaternion();
                    GameObject globoesp  = Instantiate(globo_especial,new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                    globoesp.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocidadGlobosp),UnityEngine.ForceMode2D.Impulse); //instancio y agrego velocidad
                    cont_especial = 0; //con esto no entra mas al ultimo if (cont_especial >= 50.0f)

                }
        }
          
        else{

             stopReallySpawn();
             parar = false; 
          
            }

        if (cont_especial >= 50.0f){ //se instancia por primera vez a los 50 segundos.

            inst_globo_esp = true;
       
        }
          
        
    }
      

    
}