using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyCharacterPool : MonoBehaviour
{
    private static FriendlyCharacterPool _instance;
    public static FriendlyCharacterPool Instance { get { return _instance; } }

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

    public List<GameObject> friendlyCharacterList = new List<GameObject>();
}
