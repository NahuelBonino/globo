using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globo_spawn_lvl1 : MonoBehaviour
{
    public GameObject[] globosObj1;
    public GameObject[] globosObj2;
    public GameObject globo_especial;

 
    public int cant_globosObj1;
    public int cant_globosObj2;
    float Ran;
    float cont_normal;
    float cont_especial;
    float contador_nivel;

    float contador_esperar;

    float velocidadGlobosp;
    int tiempo;
    
    bool parar;
    void Start()
    {
        cont_normal = 0;
        cont_especial = 0;
        parar = true; 
        velocidadGlobosp = 1.5f;
        tiempo = 0;
    }

    // Update is called once per frame
    
    public void SetVelocidadGlobo(float velocidad){

        velocidadGlobosp = velocidad;
    }
    public void stopSpawnforMoment(int i){
      parar = true;
      tiempo = i;
    }
    

    IEnumerator stopReallySpawn(int i){       
         yield return new WaitForSeconds (i);    
         parar = false;
    }

    void Update()
    {        
       if (!parar){ //inicio sin globos

           cont_normal = cont_normal + Time.deltaTime;
           cont_especial = cont_especial + Time.deltaTime;
        if(Crtl_Objetivos_lvl1.getInstance().getCurrentObj()==1){ // Globos del objetivo 1           
       
            if (cont_normal >= 1.5f)
            {
                Ran = Random.Range(-2.7f, 2.7f);
                int Ran2 = Random.Range(0,cant_globosObj1);
               // print(Ran2);
                Quaternion q = new Quaternion();
                GameObject globo =  Instantiate(globosObj1[Ran2],new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                globo_explot ge = globo.GetComponent(typeof(globo_explot)) as globo_explot;
                ge.setLvl(1);
                globo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocidadGlobosp),UnityEngine.ForceMode2D.Impulse); //instancio y agrego velocidad
                globo.GetComponent<BoxCollider2D>().isTrigger = true; // para que no interactuen entre ellos
                cont_normal = 0;
            }
        }
        else if (Crtl_Objetivos_lvl1.getInstance().getCurrentObj()==2){ //Globos del objetivo 2
             
          
             if (cont_normal >= 0.4f) //GLOBOS NORMALES
            {
                Ran = Random.Range(-2.7f, 2.7f);
                int Ran2 = Random.Range(0,cant_globosObj2);
               // print(Ran2);
                Quaternion q = new Quaternion();
                GameObject globo =  Instantiate(globosObj2[Ran2],new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                globo_explot ge = globo.GetComponent(typeof(globo_explot)) as globo_explot;
                ge.setLvl(1);
                globo.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, velocidadGlobosp),UnityEngine.ForceMode2D.Impulse); //instancio y agrego velocidad
                cont_normal = 0;
                globo.GetComponent<BoxCollider2D>().isTrigger = true; // para que no interactuen entre ellos
            }
            /*if (cont_especial >= 5.0f){ //GLOBO ESPECIAL (EXPLOSION MULTIPLE)

                Ran = Random.Range(-3f, 3f);               
               // print(Ran2);
                Quaternion q = new Quaternion();
                Instantiate(globo_especial,new Vector3(Ran,GetComponent<Transform>().position.y,1f),q);
                cont_especial = 0;

            }*/

          }// Globos del objetivo 2
       
       /* if (cont_especial >= 4f) {

            Ran = Random.Range(-3f, 3f);
            Quaternion q = new Quaternion();
            Instantiate(globo_especial, new Vector3(Ran, -7f, 0f), q);
            cont_especial = 0;
        }*/
      }
      else{
           StartCoroutine(stopReallySpawn(tiempo));
      }
    }
}