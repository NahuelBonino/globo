using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CtrScene : MonoBehaviour
{
    static public int NivelesDesbloqueado = 0;
    public int NivelActual = 0;
    public Button[] botones;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu")) {
            ActualizarBotones();
        }
    }
    public void CambiarNivel(int nivel) {

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
  
