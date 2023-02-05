using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootLevelLevelUpButton : MonoBehaviour
{
    public RootLevelCenter rootLevelCenter;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { 
        rootLevelCenter.LevelUp();
        });
    }
}
