using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveLimit : MonoBehaviour
{
    private static MouseMoveLimit _instance;
    public static MouseMoveLimit Instance { get { return _instance; } }

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

    public Transform up;
    public Transform down;
    public Transform right;
    public Transform left;
}
