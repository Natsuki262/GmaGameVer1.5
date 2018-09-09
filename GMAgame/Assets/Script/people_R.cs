using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_R : MonoBehaviour {

    float speed;        //移動速度

    // Use this for initialization
    void Start()
    {
        //移動速度をランダムに設定する
        speed = Random.Range(0.01f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        //左に向かって移動
        transform.Translate(-speed, 0, 0);
        //端まで移動したら消す
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}