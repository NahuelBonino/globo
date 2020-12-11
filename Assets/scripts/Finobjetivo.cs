using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finobjetivo : MonoBehaviour
{
    float contador;
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador >= 3.0f) {

            Destroy(gameObject);

        }
    }
}
