using UnityEngine;

public class enemy : MonoBehaviour {

    int time;           //時間(1秒で60カウント)
    int LorR;          //敵を左から出すか右から出すか(0:左　1:右)

    public GameObject people_L;
    public GameObject people_R;
    public GameObject bike_L;
    public GameObject bike_R;
    public GameObject car_L;
    public GameObject car_R;

    // Use this for initialization
    void Start () {
        //スタート前にカウントダウンが4秒あるので(4秒×60)で240カウント分マイナス
        time = -240;
	}

    // Update is called once per frame
    void Update()
    {
        time++;

        //ゲーム中であれば一定時間ごとに敵を出す
        if (time >= 0 && time <= 3600)
        {
            //2秒ごとに人を出す
            if (time % 120 == 0)
            {
                //左か右のどちらに出すか決める
                LorR = Random.Range(0, 2);
                //敵を出す
                if(LorR == 0)
                {
                    Instantiate(people_L, new Vector2(-10.0f, -3.5f), transform.rotation);
                }
                if (LorR == 1)
                {
                    Instantiate(people_R, new Vector2(10.0f, -3.5f), transform.rotation);
                }
            }

            //4秒ごとにバイクを出す
            if (time % 240 == 0)
            {
                //左か右のどちらに出すか決める
                LorR = Random.Range(0, 2);
                //敵を出す
                if (LorR == 0)
                {
                    Instantiate(bike_L, new Vector2(-10.0f, -3.5f), transform.rotation);
                }
                if (LorR == 1)
                {
                    Instantiate(bike_R, new Vector2(10.0f, -3.5f), transform.rotation);
                }
            }

            //6.5秒ごとに人を出す
            if (time % 400 == 0)
            {
                //左か右のどちらに出すか決める
                LorR = Random.Range(0, 2);
                //敵を出す
                if (LorR == 0)
                {
                    Instantiate(car_L, new Vector2(-10.0f, -3.8f), transform.rotation);
                }
                if (LorR == 1)
                {
                    Instantiate(car_R, new Vector2(10.0f, -3.8f), transform.rotation);
                }
            }
        }
    }
}
