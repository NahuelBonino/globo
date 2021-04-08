using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globoEspMove : MonoBehaviour{

    Transform t;
    float cont;

    float aumento;
    float movhor;
    bool izq;
   
    void Start()
    {
        movhor = 0.01f;   
        cont = 0;
        aumento=0;
        izq=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        cont += Time.deltaTime;
        if (cont >= 0.05f){

            Vector3 tempPosition = new Vector3(movhor,0,0);
           // Vector3 tempRotation = new Vector3(0,0,movhor);
            transform.position += tempPosition;   
            var rot = transform.rotation;
            rot.z += Time.deltaTime * (-1) * movhor * 10;
            transform.rotation = rot;

            if (aumento<0.5f && !izq){ //hasta que no llegue a determinado aumento no paro
            
              movhor = 0.05f;
              
            }
            else if(aumento>=0.5f){
                izq=true;
            }
            if (aumento>-0.5f && izq){
                 
              movhor = -0.05f;
             
            }
            else if(aumento<=-0.5f){
                izq=false;
            }

         aumento += movhor; 
         cont=0;  
        }
    }
}
