using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultButton : MonoBehaviour {

    bool MouseButton = false;          //マウスをクリックしたか

    public AudioClip SE_Burton;         //ボタンの音

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //もう一回ボタンを押した
    public void ButtonAgain()
    {
        //ボタンを押されてない状態から押した
        if(MouseButton == false)
        {
            MouseButton = true;
            //決定音を鳴らす
            GetComponent<AudioSource>().PlayOneShot(SE_Burton);
            //GameStart関数を呼び出す
            StartCoroutine("TryAgain");
        }
    }

    //タイトルボタンを押した
    public void ButtonTitle()
    {
        //ボタンを押されてない状態から押した
        if (MouseButton == false)
        {
            MouseButton = true;
            //決定音を鳴らす
            GetComponent<AudioSource>().PlayOneShot(SE_Burton);
            //GameStart関数を呼び出す
            StartCoroutine("GameEnd");
        }
    }

    //少し待ってシーン遷移(もう一回)
    IEnumerator TryAgain()
    {
        // 1.5秒待つ
        yield return new WaitForSeconds(1.5f);
        //シーンの移動
        SceneManager.LoadScene("MainScene");

    }

    //少し待ってシーン遷移(タイトル)
    IEnumerator GameEnd()
    {
        // 1.5秒待つ
        yield return new WaitForSeconds(1.5f);
        //シーンの移動
        SceneManager.LoadScene("TitleScene");
    }
}
