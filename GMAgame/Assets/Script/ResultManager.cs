using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour {
    private int resultScore;
    private Text ResultScore;

    // Use this for initialization
    void Start ()
    {
        resultScore = ScoreManager.ResutScore();
        Debug.Log(resultScore);
        ResultScore = GameObject.Find("ResultScore").GetComponent<Text>();
        ResultScore.text = "000"+resultScore;
    }
	
	// Update is called once per frame
	void Update ()
    {
       

    }
    public void PushTileButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
