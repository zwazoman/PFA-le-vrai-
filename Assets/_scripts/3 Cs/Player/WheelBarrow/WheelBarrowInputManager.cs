using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// inputs quand le joueur porte la brouette
/// </summary>
public class WheelBarrowInputManager : MonoBehaviour
{
    public float MoveInput { get; private set; }
    public float TurnInput { get; private set; }

    public event Action OnDrop;

    public event Action OnEmpty;

    public event Action OnMove;

    public event Action OnStop;

    public event Action OnStartSprint;

    public event Action OnStopSprint;

    public event Action OnPause;
    public void Move(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        MoveInput = context.ReadValue<float>();
        if (context.performed) OnMove?.Invoke(); else if (context.canceled) OnStop?.Invoke();
    }

    public void Turn(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        TurnInput = context.ReadValue<float>();
    }

    public void Drop(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        if (context.performed)
        {
            OnDrop?.Invoke();
        }

    }

    public void Empty(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        if (context.performed)
        {
            print("empty");
            OnEmpty?.Invoke();
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        if (context.performed)
        {
            OnStartSprint?.Invoke();
        }
        if (context.canceled)
        {
            OnStopSprint?.Invoke();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        //if (!enabled) return;
        if (context.performed) 
        {
            //print("con");
            OnPause?.Invoke();
        }
        
    }
    private void OnDisable()
    {
        TurnInput = 0;
        MoveInput = 0;
    }
}
