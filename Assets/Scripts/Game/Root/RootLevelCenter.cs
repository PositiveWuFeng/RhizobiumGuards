using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootLevelCenter : MonoBehaviour
{
    public GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        root.SetActive(!root.activeSelf);


    }

    public void LevelUp()
    {
        Debug.Log("@_@");
        if(PlayerData.gold >= 5 && PlayerData.rootLevel < 5)
        {
            PlayerData.gold -= 5;
            PlayerData.rootLevel++;
            PlayerData.maxPeopleNum = LevelConfigData.data[PlayerData.rootLevel - 1].MaxPeople;
        }
    }

    
}
