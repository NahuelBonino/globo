using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNubes : MonoBehaviour
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

        if(contadorvida>=2.5f){

            Destroy(this.gameObject);

        }
    }
}
