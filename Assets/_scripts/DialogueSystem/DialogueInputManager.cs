using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInputManager : MonoBehaviour
{
    //public event Action OnSkip;

    public static bool _keyDown = false;
    public static bool _keyUp = false;
    public static bool _keyHold = false;


    public void Submit(InputAction.CallbackContext ctx)
    {

        /*if (context.duration < 0.5f)
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
        }*/


        StartCoroutine(UpdateKeyInfo(ctx));
    }

    IEnumerator UpdateKeyInfo(InputAction.CallbackContext ctx)
    {
        print("abcde");
        if (ctx.performed)
        {
            print("le putain de perdormed a ete performé tu m'entends?");
            // On Button Down
            _keyHold = true;

            _keyDown = true;
            yield return 0;
            _keyDown = false;
        }
        else if (ctx.canceled)
        {
            _keyHold = false;

            // On Button Up
            _keyUp = true;
            yield return 0;
            _keyUp = false;


        }
    }
}
