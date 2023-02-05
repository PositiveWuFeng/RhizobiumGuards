using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
public static class PlayerData
{
    private static float _gold;
    public static float gold
    {
        get { return _gold; }
        set {
            _gold = value;
            GameMenuManager.Instance.FreshUI(); 
        }
    }

    private static int _rootLevel;
    public static int rootLevel
    {
        get { return _rootLevel; }
        set {
            _rootLevel = value;
            GameMenuManager.Instance.FreshUI();
        }
    }

    private static int _peopleNum;
    public static int peopleNum
    {
        get { return _peopleNum; }
        set
        {
            _peopleNum = value;
            if(_peopleNum <= 0)
            {
                GameManager.Instance.EndFight(false);
            }
            GameMenuManager.Instance.FreshUI();
        }
     }

    private static int _maxPeopleNum;
    public static int maxPeopleNum
    {
        get { return _maxPeopleNum; }
        set
        {
            _maxPeopleNum = value;
            GameMenuManager.Instance.FreshUI();
        }
    }

    public static int rounds;

    public static void Init()
    {
        _gold =3;
        _rootLevel = 1;
        _peopleNum = 0;
        _maxPeopleNum = LevelConfigData.data[0].MaxPeople;
        rounds = 1;
    }

    
}
