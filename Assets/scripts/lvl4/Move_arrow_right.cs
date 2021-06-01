using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_arrow_right : MonoBehaviour
{
    public Transform punta;
    float movementSpeed;
    void Awake()
    {
        movementSpeed = 10f;
        punta =  GameObject.Find("punta").GetComponent(typeof(Transform)) as Transform;

    }
   void OnMouseDrag() {
        
        if (punta.position.x <= 2.65f ){

            punta.position += new Vector3(movementSpeed * Time.deltaTime,0f,0f); 

        }

       
   }

}