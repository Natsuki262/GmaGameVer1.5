using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_L : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float inhaleSpeed;

    private bool hitflag=false;

    

    enum State
    {   Idle,//待機中
        Inhale,//空中
        Falling//落下状態
    };
    State state = State.Idle;


    [SerializeField]
    private int addScoreValue;
    private ScoreManager sm;


    // Use this for initialization
    void Start()
    {

        moveSpeed = Random.Range(minSpeed, maxSpeed);
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
       

        switch (state)
        {
            case State.Idle:
                //Debug.Log("<color=red>idle</color>");
                break;
            case State.Inhale:
                //Debug.Log("<color=red>Inhale</color>");
                break;
            case State.Falling:
                Debug.Log("<color=red>Falling</color>");
                break;
        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UfoAbduction")
        {
            //Debug.Log("hit2");
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * inhaleSpeed);
             
        }

        if (collision.gameObject.tag == "UFO")
        {
            Debug.Log("Ufohit");
            sm.ScoreAdd(addScoreValue);
            Destroy(this.gameObject);
        }
        state = State.Inhale;
        hitflag = true;
    }
     void OnCollsionExit2D(Collision2D collision)
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * inhaleSpeed);
       state = State.Falling;
        hitflag = false;
    }


}
