using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bike_L : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public int AddScoreVal;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float inhaleSpeed;
    
   readonly private int widthLimit = Screen.width;



    private ScoreManager Sm;


    // Use this for initialization
    void Start()
    {
      
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
        
        if (transform.position.x > widthLimit)
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
            Sm.ScoreAdd(AddScoreVal);
            Destroy(this.gameObject);
        }


    }
}
