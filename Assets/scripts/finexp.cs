using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finexp : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 1.5f) {
            Destroy(gameObject); 
        }

    }
}
