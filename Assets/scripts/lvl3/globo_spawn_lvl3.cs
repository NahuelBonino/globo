using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globo_spawn_lvl3 : MonoBehaviour
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

    public float tiempo_entre_globo;
    
    
    bool parar;
    void Start()
    {
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
        //   cont_especial = cont_especial + Time.deltaTime;
           if(Crtl_Objetivos_lvl3.getInstance().getCurrentObj()==1){ // Globos del objetivo 1
                    
                if (cont_normal >= tiempo_entre_globo){
                     Debug.Log("tiempo entre globos " + tiempo_entre_globo.ToString());
                    Ran = Random.Range(-2.7f, 2.7f);
                    int Ran2 = Random.Range(0,cant_globosObj1);
                    Quaternion q = new Quaternion();
                    GameObject globo = Instantiate(globosObj1[Ran2],new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                    globo_explot ge = globo.GetComponent(typeof(globo_explot)) as globo_explot;
                    ge.setLvl(3); //le aviso que es el nivel 3
                    globo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocidadGlobosp),UnityEngine.ForceMode2D.Impulse); //instancio y agrego velocidad
                    cont_normal = 0f;
                    globo.GetComponent<BoxCollider2D>().isTrigger = true;
                }
                
            }           
                /*if (cont_especial >= 5.0f){ //GLOBO ESPECIAL (EXPLOSION MULTIPLE)

                    Ran = Random.Range(-3f, 3f);               
                // print(Ran2);
                    Quaternion q = new Quaternion();
                    Instantiate(globo_especial,new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                    cont_especial = 0;

                }*/

        }
          
        else{

             stopReallySpawn();
             parar = false; 
          
            }
          
    }
      

    
}