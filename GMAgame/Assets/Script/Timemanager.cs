using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timemanager : MonoBehaviour {

    //現在の状態
    public enum GameState
    {
        CountDown,      //スタート前のカウントダウン
        OnGameMain,     //ゲーム中
        GameOver        //ゲーム終わり
    }

    //☆時間について！
    //0:00～6:00まで実際の時間で1分
    //...なので1/6秒ごとにゲーム内の分のカウントを1分進めると、「ゲーム内の6時間=実際の時間で1分」になる☆彡
    [SerializeField]
    int endCount;       //カウントダウン終了時間


    GameState game_state;     //現在の状態

    int time;           //時間のカウント(1/60ごとにカウント)
    int minFirstDigit;          //分(1の位)
    int minSecondDigit;         //分(10の位)
    int hou;            //時
    float bg;           //背景画像の座標

    Transform start_countdown_transform;

    // Use this for initialization
    void Start () {
        //初期値
        game_state = GameState.CountDown;
        time = 0;
        minFirstDigit = 0;
        minSecondDigit = 0;
        hou = 0;
        bg = -2.0f;
        
        start_countdown_transform = GameObject.Find("start_countdown").transform;
    }
	
	// Update is called once per frame
	void Update () {
        //1/60ごとにカウントを増やす
        time++;

        //現在の状態に合わせた処理をする
        switch(game_state)
        {
            //スタート前のカウントダウン
            case GameState.CountDown:
                //カウントダウンの表示が終わった(4秒経った)
                if(time == endCount)
                {
                    //カウントダウンのテロップ文字の移動
                    start_countdown_transform.position = new Vector2(0, -10);
                    //カウントをリセット
                    time = 0;
                    game_state = GameState.OnGameMain;
                }
                break;
            //ゲーム中
            case GameState.OnGameMain:
                //1/6ごと(つまり「time=10」)にゲーム内の分のカウントを進める
                if (time == 10)
                {
                    //カウントをリセット
                    time = 0;

                    //分のカウントを進める
                    minFirstDigit++;

                    //5時以降は背景の色を少しづつ変えていく
                    if (hou == 5)
                    {
                        //現在の背景座標に値を足して上にずらしていく
                        bg += 0.1f;
                        //背景画像の移動
                        GameObject.Find("BG_sky").transform.position = new Vector2(0, bg);
                    }

                    //1の位が10になったら繰り上がり
                    if (minFirstDigit == 10)
                    {
                        minSecondDigit++;
                        minFirstDigit = 0;

                        //10の位が6になったら、分のカウントを0にして時間のカウントを1進める
                        if (minSecondDigit == 6)
                        {
                            hou++;
                            minSecondDigit = 0;

                            //6時になったらタイムアップと表示して終了
                            if(hou == 6)
                            {
                                game_state = GameState.GameOver;
                                //文字の表示
                                GameObject.Find("timeup").transform.position = new Vector2(0, 0);
                            }
                        }
                    }
                }

                //カウントの数を画面に反映させる
                GameObject.Find("hour").GetComponent<Text>().text = hou.ToString();
                GameObject.Find("minute_10").GetComponent<Text>().text = minSecondDigit.ToString();
                GameObject.Find("minute_1").GetComponent<Text>().text = minFirstDigit.ToString();
                break;
            //3:しゅーりょー
            case GameState.GameOver:
                break;
        }
    }
}
