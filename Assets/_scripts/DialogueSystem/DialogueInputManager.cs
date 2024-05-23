using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInputManager : MonoBehaviour
{
    public event Action OnSkip;

    public void Submit(InputAction.CallbackContext context)
    {
        print("skip");
        if (context.performed)
        {
            OnSkip?.Invoke();
        }
    }
}
