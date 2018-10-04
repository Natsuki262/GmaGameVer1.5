using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_L : MonoBehaviour {

    private float moveSpeed;        //移動速度
    public int ScoreValue;//得点格納変数
    private ScoreManager Sm;//Scoremanager型を定義


    // Use this for initialization
    void Start ()
    {
        //移動速度をランダムに設定する
		moveSpeed = Random.Range(0.01f, 0.03f);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //右に向かって移動
        transform.Translate(moveSpeed, 0, 0);
        //端まで移動したら消す
        if (transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UfoAbduction")
        {
            Debug.Log("hit2");
            this.gameObject.transform.Translate(0f, 3f, 0);

        }
        if (collision.gameObject.tag == "UFO")

        {
            Debug.Log("Ufohit");
            Sm.ScoreAdd(ScoreValue);
            Destroy(this.gameObject);
        }


    }

}
