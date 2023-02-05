// using System.Numerics;
// using System.Threading.Tasks.Dataflow;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatPoint : MonoBehaviour
{
    private static FloatPoint _instance;
    public static FloatPoint Instance { get { return _instance; } }

    public GameObject floatPoint;
    // [SerializeField] private float destroyTime;
    [SerializeField] private float time;
    [SerializeField] private TMP_Text damageText = null;


    public void DamageFloatPoint(int damage)
    {
        damageText.text = damage.ToString();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 1.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
