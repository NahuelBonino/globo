using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punta_explot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){       
      globo_explot globo = GameObject.Find(col.gameObject.name).GetComponent(typeof(globo_explot)) as globo_explot;
      globo.explot();
    }
}
