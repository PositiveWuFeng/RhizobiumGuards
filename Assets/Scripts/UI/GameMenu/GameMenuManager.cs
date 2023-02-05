using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{

    private static GameMenuManager _instance;
    public static GameMenuManager Instance { get { return _instance; } }

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

    public GameObject root;

    public Text PeopleNumText;
    public Text GoldText;

    public Button StartFightButton;

    private void Start()
    {
        StartFightButton.onClick.AddListener(() => {
            StartFight();
        });
    }

    public void Show()
    {
        root.SetActive(true);
        FreshUI();
    }

    public void Hide()
    {
        root?.SetActive(false);
    }

    public void FreshUI()
    {
        PeopleNumText.text = PlayerData.peopleNum + "/" + PlayerData.maxPeopleNum;
        GoldText.text = PlayerData.gold.ToString();
    }

    public void ShowFightButton()
    {
        StartFightButton.gameObject.SetActive(true);
    }

    public void StartFight()
    {
        GameManager.Instance.StartFight();
        StartFightButton.gameObject.SetActive(false);
    }
}
