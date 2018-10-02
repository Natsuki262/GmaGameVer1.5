using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timemanager : MonoBehaviour {

    //☆時間について！
    //0:00～6:00まで実際の時間で1分
    //...なので1/6秒ごとにゲーム内の分のカウントを1分進めると、「ゲーム内の6時間=実際の時間で1分」になる☆彡

    int game_state;     //現在の状態(1:スタート前のカウントダウン　2:ゲーム中　3:しゅーりょー)

    int time;           //時間のカウント(1/60ごとにカウント)
    int min_1;          //分(1の位)
    int min_10;         //分(10の位)
    int hou;            //時
    float bg;           //背景画像の座標

    Transform start_countdown_transform;

    // Use this for initialization
    void Start () {
        //初期値
        game_state = 1;
        time = 0;
        min_1 = 0;
        min_10 = 0;
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
            //1:スタート前のカウントダウン
            case 1:
                //カウントダウンの表示が終わった(4秒経った)
                if(time == 240)
                {
                    //カウントダウンのテロップ文字の移動
                    start_countdown_transform.position = new Vector2(0, -10);
                    //カウントをリセット
                    time = 0;
                    game_state = 2;
                }
                break;
            //2:ゲーム中
            case 2:
                //1/6ごと(つまり「time=10」)にゲーム内の分のカウントを進める
                if (time == 10)
                {
                    //カウントをリセット
                    time = 0;

                    //分のカウントを進める
                    min_1++;

                    //5時以降は背景の色を少しづつ変えていく
                    if (hou == 5)
                    {
                        //現在の背景座標に値を足して上にずらしていく
                        bg += 0.1f;
                        //背景画像の移動
                        GameObject.Find("BG_sky").transform.position = new Vector2(0, bg);
                    }

                    //1の位が10になったら繰り上がり
                    if (min_1 == 10)
                    {
                        min_10++;
                        min_1 = 0;

                        //10の位が6になったら、分のカウントを0にして時間のカウントを1進める
                        if (min_10 == 6)
                        {
                            hou++;
                            min_10 = 0;

                            //6時になったらタイムアップと表示して終了
                            if(hou == 6)
                            {
                                game_state = 3;
                                //文字の表示
                                GameObject.Find("timeup").transform.position = new Vector2(0, 0);
                            }
                        }
                    }
                }

                //カウントの数を画面に反映させる
                GameObject.Find("hour").GetComponent<Text>().text = hou.ToString();
                GameObject.Find("minute_10").GetComponent<Text>().text = min_10.ToString();
                GameObject.Find("minute_1").GetComponent<Text>().text = min_1.ToString();
                break;
            //3:しゅーりょー
            case 3:
                break;
        }
    }
}
