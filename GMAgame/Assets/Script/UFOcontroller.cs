using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOcontroller : MonoBehaviour
{
    //変数


    private float Velocity = 0f;//UFOの初期速度[
   private float swipeLength;//スワイプの長さ
    [SerializeField]
    private float slowingDown;


    //型
    Vector2 UfoPos;//クリック開始
    Vector2 UfoEndPos;//クリック終了
    Vector2 Min;
    Vector2 Max;
    Vector2 NowUfoPos;

    [SerializeField]
    GameObject Ufohoge;
    


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveUfo();
        MovementLimit();
        Abduction();
        
  


    }
    void MoveUfo()
    {
        ///変数
       

        if (Input.GetMouseButtonDown(0))
        {

            //マウスクリック座標
            this.UfoPos = Input.mousePosition;  
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //マウスを離した座標


            UfoEndPos = Input.mousePosition;
            swipeLength = (UfoEndPos.x - this.UfoPos.x);
            this.Velocity = swipeLength / 500.0f;
        }

        transform.Translate(this.Velocity, 0, 0);//移動
        this.Velocity *= slowingDown;       
        
    }
    void MovementLimit()
    {
        //画面ワールド座標をビューポートから取得
        Min = Camera.main.ViewportToWorldPoint(new Vector2(0.18f, -0f));

        //画面ワールド座標をビューポートから取得

        Max = Camera.main.ViewportToWorldPoint(new Vector2(0.811f,0f));

        NowUfoPos = transform.position;

        NowUfoPos.x = Mathf.Clamp(NowUfoPos.x, Min.x, Max.x);

        transform.position = NowUfoPos;
    }
    void Abduction()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }


        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        
    }
    /*void OnCollisionEnter2D(Collision2D collision)
   {
       if(collision.gameObject.tag== "People_L")
       {
           Debug.Log("hit");
       }
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
   }*/
    void OnTriggerStay(Collider other)
    {
        Debug.Log("通過");
        if (other.gameObject.tag == "People_L")
        {
            Debug.Log("hit"+other.gameObject.tag);
        }
    }
}
