using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_L : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float inhaleSpeed;

    readonly private int widthLimit = Screen.width;

    [SerializeField]
    private int addScoreValue;//得点格納変数
    private ScoreManager Sm;//Scoremanager型を定義



    // Use this for initialization
    void Start ()
    {
        
		moveSpeed = Random.Range(minSpeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
      
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UfoAbduction")
        {
            Debug.Log("hit2");
            this.gameObject.transform.Translate(Vector3.up*Time.deltaTime*inhaleSpeed);

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
