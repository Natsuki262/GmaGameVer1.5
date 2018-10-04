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


    public int ScoreValue;//得点格納変数
    private ScoreManager Sm;//Scoremanager型を定義



    // Use this for initialization
    void Start ()
    {
        //移動速度をランダムに設定する
		moveSpeed = Random.Range(minSpeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //右に向かって移動
        transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
        //端まで移動したら消す
        if (transform.position.x > widthLimit)
        {
            Destroy(gameObject);
        }
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
            Sm.ScoreAdd(ScoreValue);
            Destroy(this.gameObject);
        }


    }

}
