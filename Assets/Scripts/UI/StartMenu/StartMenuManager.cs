using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    private static StartMenuManager _instance;
    public static StartMenuManager Instance { get { return _instance; } }

    public GameObject settingPlane;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowSetting()
    {
        settingPlane.SetActive(true);
    }
}
