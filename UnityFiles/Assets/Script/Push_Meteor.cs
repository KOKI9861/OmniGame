using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Meteor : MonoBehaviour
{
    GameObject MeteorPrefab; // 隕石のプレハブ
    GameObject MeteorsParent; // 隕石をまとめる親オブジェクト
    float minTime = 0.5f;
    float maxTime = 2f;
    float interval;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        MeteorPrefab = (GameObject)Resources.Load("Prefab/Meteor");
        MeteorsParent = GameObject.Find("Meteors");
        interval = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        push_Meteors();
    }

    void push_Meteors()
    {
        // 時間経過で隕石を発射
        time += Time.deltaTime;
 
        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if(time > interval)
        {
            Instantiate(MeteorPrefab).transform.parent = MeteorsParent.transform;
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = Random.Range(minTime, maxTime);

        }
    }
}
