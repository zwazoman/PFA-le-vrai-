using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelBarrowInputManager : MonoBehaviour
{
    public float MoveInput { get; private set; }
    public float TurnInput { get; private set; }

    public event Action OnDrop;

    public event Action OnEmpty;

    public event Action OnStartSprint;

    public event Action OnStopSprint;
    public void Move(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<float>();
    }

    public void Turn(InputAction.CallbackContext context)
    {
        TurnInput = context.ReadValue<float>();
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDrop?.Invoke();
        }

    }

    public void Empty(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("empty");
            OnEmpty?.Invoke();
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnStartSprint?.Invoke();
        }
        if (context.canceled)
        {
            OnStopSprint?.Invoke();
        }
    }
}
