using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAndAgain: MonoBehaviour {

     //スタートの音

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        
    }

    //少し待ってシーン遷移
    IEnumerator GameStart()
    {
        // 1.5秒待つ
        yield return new WaitForSeconds(1.5f); 
       
    }
   public void PushStartButton()
    {
        SceneManager.LoadScene("MainScene");
       
    }
}
