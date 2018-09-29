using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    private int Score = 0;
    private Text ScoreCount;//scoreのUIオブジェクト

    // Use this for initialization
    void Start()
    {
        ScoreCount = GameObject.Find("ScoreCount").GetComponent<Text>();
        ScoreCount.text = "Score:" + Score;
    }

    // Update is called once per frame
    void Update()

    {

    }
    //外部からもアクセスするので公開定義
    public void ScoreAdd(int ScoreData)
    {
        Score += ScoreData;
        ScoreCount.text = "Score:" + Score;
    }
}
