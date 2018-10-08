﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_L : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float minspeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float inahleSpeed;

    readonly private int widthLimit = Screen.width;
    [SerializeField]
    private int addScoreValue;
    private ScoreManager Sm;


    // Use this for initialization
    void Start()
    {
      
        moveSpeed = Random.Range(minspeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
       
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UfoAbduction")
        {
            Debug.Log("Carhit");
            this.gameObject.transform.Translate(Vector3.up*Time.deltaTime*inahleSpeed);
        }
        if (collision.gameObject.tag == "UFO")

        {
            Debug.Log("Ufohit");
            Sm.ScoreAdd(addScoreValue);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag=="outArea_L")
        {
            Destroy(gameObject);
        }

    }
}
