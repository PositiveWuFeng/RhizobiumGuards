using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiDiLevel : MonoBehaviour
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
            int t = PlayerData.rootLevel;
            text.text = "根茎等级 " + t.ToString() + "/5";
            time = 0;
        }
    }
}
