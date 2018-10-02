using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bike_L : MonoBehaviour {
    [SerializeField]
    private float speed;

    [SerializeField]
    public int AddScoreVal;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    
   readonly int widthLimit = Screen.width;


    private ScoreManager Sm;//Scoremanager型を定義


    // Use this for initialization
    void Start()
    {
        //移動速度をランダムに設定する
        speed = Random.Range(minSpeed, maxSpeed);
        Sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //右に向かって移動
        transform.Translate(speed, 0, 0);
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
            Debug.Log("hit1");
            this.gameObject.transform.Translate(0f, 1.3f, 0);

        }
        if (collision.gameObject.tag == "UFO")

        {
            Debug.Log("Ufohit");
            Sm.ScoreAdd(AddScoreVal);
            Destroy(this.gameObject);
        }


    }
}
