using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartStory : MonoBehaviour
{
    public List<string> s;
    public Text text;
    public Image panel;

    public void aaa()
    {
        panel.gameObject.SetActive(true);
        StartCoroutine(startPlay());
    }
    
    IEnumerator startPlay()
    {
        foreach (var i in s)
        {
            yield return new WaitForSeconds(0.5f);
            text.text = i;
            text.DOFade(1, 0.5f);
            yield return new WaitForSeconds(3f);
            text.DOFade(0, 0.5f);
        }

        panel.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        panel.gameObject.SetActive(false);
    }
}
