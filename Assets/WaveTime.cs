using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTime : MonoBehaviour
{
    private float time = 0;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f)
        {
            int t = CreateEnemyManager.Instance.curNum;
            text.text = "当前轮次 " + t.ToString() + "/12";
            time = 0;
        }
    }
}
