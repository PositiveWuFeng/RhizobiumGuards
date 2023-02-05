using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        CharacterManager.Instance.StartCombat();
    }
}
