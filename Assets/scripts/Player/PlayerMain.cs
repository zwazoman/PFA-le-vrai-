using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{

    [field: SerializeField]
    public PlayerInputManager InputManager { get; private set; }

    [field: SerializeField]
    public PlayerMovement Movement { get; private set; }

    //init du singleton
    private static PlayerMain instance = null;
    public static PlayerMain Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
