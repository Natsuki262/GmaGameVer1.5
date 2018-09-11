using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_L : MonoBehaviour {

    float speed;        //移動速度

    // Use this for initialization
    void Start()
    {
        //移動速度をランダムに設定する
        speed = Random.Range(0.05f, 0.07f);
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
}
