using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bike_R : MonoBehaviour {
    
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float inhaleSpeed;

    [SerializeField]
    private int addScoreVal;
    private ScoreManager Sm;

    readonly private int widthLimit = Screen.width;

    // Use this for initialization
    void Start()
    {
       
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //左に向かって移動
        transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
        //端まで移動したら消す
        if (transform.position.x < widthLimit)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UfoAbduction")
        {
            Debug.Log("hit1");
            this.gameObject.transform.Translate(Vector3.up*Time.deltaTime*inhaleSpeed);


        }
        if (collision.gameObject.tag == "UFO")

        {
            Debug.Log("UfoHit");
            Sm.ScoreAdd(addScoreVal);
            Destroy(this.gameObject);
        }




    }
}
