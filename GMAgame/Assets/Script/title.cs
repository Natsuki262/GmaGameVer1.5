using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {

    bool MouseButton = false;          //マウスをクリックしたか

    public AudioClip SE_Start;         //スタートの音

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //左クリックがされたら
        if (Input.GetMouseButtonDown(0) && MouseButton == false)
        {
            MouseButton = true;
            //BGMを止める
            GetComponent<AudioSource>().Stop();
            //決定音を鳴らす
            GetComponent<AudioSource>().PlayOneShot(SE_Start);
            //GameStart関数を呼び出す
            StartCoroutine("GameStart");
        }
    }

    //少し待ってシーン遷移
    IEnumerator GameStart()
    {
        // 1.5秒待つ
        yield return new WaitForSeconds(1.5f); 
        //シーンの移動
        SceneManager.LoadScene("MainScene");
    }
}
