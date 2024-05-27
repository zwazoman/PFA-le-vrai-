using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInputManager : MonoBehaviour
{
    public event Action OnSkip;

    bool _keyDown;
    bool _keyUp;
    bool _keyHold;

    public void Submit(InputAction.CallbackContext context)
    {
        
        if (context.duration < 0.5f)
        {
            _keyDown = true;
        }

        if (context.canceled)
        {           
            StartCoroutine(RestartBool());         
        }

        if (context.duration > 1f)
        {
            _keyHold = true;
        }

        IEnumerator RestartBool()
        {
            _keyDown = false;
            _keyHold = false;
            _keyUp = true;
            yield return 0;
            _keyUp = false;
        }

    }
}
