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
        contador += Time.deltaTime;
        if (contador >= 4.0f) {

            Destroy(gameObject);

        }
    }
}
