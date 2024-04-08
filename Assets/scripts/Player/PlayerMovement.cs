using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerMain _main;
    private void Start()
    {
        _main = PlayerMain.Instance;
        _main.InputManager.OnMove += Move;
    }

    private void Move()
    {
        //
    }
}
