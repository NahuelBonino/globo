using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrScene : MonoBehaviour{
   
    static public int nivelesDesbloqueados;
    public int NivelActual;
    public Button[] botones;
    public GameObject nubes;
    private int nivel = 0;
    CargarYGuardar cyg;
    
 //   private static CtrScene instance;//instancia del singleton

    void Awake (){ //SINGLETON
   
        cyg = GetComponent<CargarYGuardar>();
       
     }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu")) {
            // print("niveles desbloqueados " + nivelesDesbloqueados.ToString());
             cyg.Guardar();
             ActualizarBotones();
        }
    //lvl1 = GameObject.Find("Atardecer").GetComponent (typeof(Button)) as Button;       
   // lvl2 = GameObject.Find("Noche").GetComponent(typeof(Button)) as Button;            
   // lvl3 = GameObject.Find("?").GetComponent(typeof(Button)) as Button; 
               
    }

    public void trans(){

      Instantiate(nubes); 

    }

    public void CambiarNivel(int niv) {
        //instancio transicion (Nubes)
        this.nivel = niv;
        Instantiate(nubes);   
        Invoke("Transicion", 1.0f); 
    }
   
     void Transicion(){
    
            if (nivel > 0)
            {
                SceneManager.LoadScene("Nivel" + nivel);
            }
            else
                SceneManager.LoadScene("Menu");
                ActualizarBotones();            
     }

    public void VolverMenu()
    {
        CambiarNivel(0);
        NivelActual = 0;
    }

    public void desbloquearNivel() {
        NivelActual++;
        print("nivel actual " + NivelActual.ToString());
        if (nivelesDesbloqueados < NivelActual) {
            nivelesDesbloqueados = NivelActual;
        }     
        VolverMenu();
    }

    public void ActualizarBotones()
    {
       // obtenerBotones();
        print(nivelesDesbloqueados.ToString());
        for (int i = 0; i <= nivelesDesbloqueados; i++)
        {
            botones[i].interactable = true;
        }

    }


    /*public void obtenerBotones(){
                  
        for (int i = 0; i <= cant_niveles-1; i++){
            botones[i] = GameObject.Find(i.ToString()).GetComponent (typeof(Button)) as Button; 
       } 

    }*/

}
  
