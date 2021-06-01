using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Print_desp : MonoBehaviour
{

    public GameObject drawPrefab;
    GameObject TheTrail; 
    Plane PlaneObj;
    Vector3 startPos;
    void Start()
    {
        PlaneObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
        //width = (float)Screen.width / 2.0f;
       // height = (float)Screen.height / 2.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
         if (Input.touchCount > 0){

              Touch touch = Input.GetTouch(0);
              if (touch.phase == TouchPhase.Began){
                 String text = "Touch Position : " + touch.position;
                 Debug.Log(text); 
                 this.transform.position = new Vector3(touch.position.x/100,touch.position.y/100,-37);
                 Quaternion q = new Quaternion();
                 TheTrail = (GameObject)Instantiate(drawPrefab,this.transform.position,q); //instancio algo que simule pintar la pantalla
                 Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);   
                  
                 float _dis;
                 if (PlaneObj.Raycast(mouseRay, out _dis)){

                     startPos = mouseRay.GetPoint(_dis);

                 }
               
              }
              else if (touch.phase == TouchPhase.Moved || Input.GetMouseButton(0)) {

                    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);   
                    float _dis;
                    if (PlaneObj.Raycast(mouseRay, out _dis)){

                         TheTrail.transform.position = mouseRay.GetPoint(_dis);

                    }

              } 
         }
    }


}
