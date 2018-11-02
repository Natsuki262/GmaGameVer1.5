using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public static int Score = 0;
    private Text ScoreCount;//scoreのUIオブジェクト

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
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
    public static int ResutScore()
    {
        return Score;
    }
}
