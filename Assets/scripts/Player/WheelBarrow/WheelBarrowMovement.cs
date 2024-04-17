using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrowMovement : DynamicObject
{
    WheelBarrowInputManager _input;

    private void Start()
    {
        _input = PlayerMain.Instance.WheelBarrow.InputManager;
    }

    private void Update()
    {
        
    }
}
