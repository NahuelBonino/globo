using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrScene : MonoBehaviour{
    static public int NivelesDesbloqueado = 0;
    public int NivelActual = 0;
    public Button[] botones;
    public GameObject nubes;
    private int nivel = 0;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu")) {
            ActualizarBotones();
        }
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
     }

    public void VolverMenu()
    {
        CambiarNivel(0);
        NivelActual = 0;
    }

    public void desbloquearNivel() {
        NivelActual++;
        if (NivelesDesbloqueado < NivelActual) {
            NivelesDesbloqueado = NivelActual;
        }     
        VolverMenu();
    }

    public void ActualizarBotones()
    {

        for (int i = 0; i <= NivelesDesbloqueado; i++)
        {

            botones[i].interactable = true;

        }

    }


}
  
