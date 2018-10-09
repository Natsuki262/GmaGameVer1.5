using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outAreaMnager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="bike")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="car")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="people")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
