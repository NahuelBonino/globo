using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinGlobos : MonoBehaviour
{
    float contadorvida;
    void Start()
    {
        contadorvida=0;
    }

    // Update is called once per frame
    void Update()
    {
        contadorvida+=Time.deltaTime;

        if(contadorvida>=15.0f){

            Destroy(this.gameObject);

        }
    }
}
