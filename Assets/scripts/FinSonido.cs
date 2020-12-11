using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinSonido : MonoBehaviour
{
    // Start is called before the first frame update

    private float contadorvida;
    void Start()
    {
        contadorvida = 0f;
    }

    // Update is called once per frame
    void Update()
    {
         contadorvida+=Time.deltaTime;

        if(contadorvida>=3.0f){

            Destroy(this.gameObject);

        }
        
    }
}
