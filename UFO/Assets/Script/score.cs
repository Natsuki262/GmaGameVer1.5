using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class score : MonoBehaviour {

    public static int sc;        //スコア

    // Use this for initialization
    void Start () {
        //スコアの初期値を設定
        sc = 0;
	}
	
	// Update is called once per frame
	void Update () {

        //score更新(D3をつけることで3桁で表示できる！)
        GetComponent<Text>().text = sc.ToString("D3");

        //スコアの加算(テスト用)
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            FindObjectOfType<score>().ScorePlus(1);
        }*/
    }

    //ポイントの追加(外部からの呼び出し可)
    public void ScorePlus(int pt)
    {
        sc += pt;
        //特定の点数を超えたら1UP
    }
}
