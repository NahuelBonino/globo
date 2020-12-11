using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrEstrellaFugaz : MonoBehaviour
{
    // Start is called before the first frame update

    

    public GameObject estrella_fugaz;
    private float contador_fugaz;

    private float Ran;

    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        contador_fugaz+= Time.deltaTime;

        if (contador_fugaz>=10.0f){

            Ran = Random.Range(-3f, 3f);
            float Ran2 = Random.Range(1.0f,4.0f);
            Quaternion q = new Quaternion();
            Instantiate(estrella_fugaz,new Vector2(0,Ran2),q);    
            contador_fugaz = 0;
        }

    }
}
