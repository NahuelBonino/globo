using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotEspacial : MonoBehaviour{

    public Transform t; 
    UnityEngine.Camera cam;
    public GameObject sound;
    public GameObject exp;

void Start()
{
    t = GetComponent<Transform>();
    cam = UnityEngine.Camera.main;
}


void OnMouseDown(){

    Destroy(gameObject);
    Instantiate(sound);
    Quaternion q = new Quaternion();
    Instantiate(exp,t.position,q);
    DestroyAll();
}



public void DestroyAll(){
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
            if (o.name.Substring(0,5).Equals("globo"))
            {                
                Instantiate(sound);
                Quaternion q = new Quaternion();
                Destroy(o);
                Instantiate(exp,o.GetComponent<Transform>().position,q);
                
            }
            
       }
}

}