using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// gère les inputs du joueur
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    private Vector2 MoveInput;
    public Vector2 moveInput => enabled ? MoveInput : Vector2.zero;//valeur de déplacement
    // event interaction du joueur
    public event Action OnInteract;
    // event début de la course du joueur
    public event Action OnSprintStart;
    // event fin de la course du joueur
    public event Action OnSprintEnd;
    // event utilisation de la houe
    public event Action OnHoe;
    // event utilisation de l'arrosoir
    public event Action OnWateringCan;
    // event utilisation de la faux
    public event Action OnScythe;
    // event utilisation de la pelle
    public event Action OnShovel;
    //event menu pause
    public event Action OnPause;

    /// <summary>
    /// gère les inputs de mouvements du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// gère les input des intéractions du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InputAction.CallbackContext context)
    {
        if(!enabled)return;

        if (context.performed ) 
        {
            OnInteract?.Invoke();
        }
    }

    /// <summary>
    /// gère les input du sprint du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Sprint(InputAction.CallbackContext context)
    {
        //if (!enabled) return;

        if (context.performed) OnSprintStart?.Invoke();
        if (context.canceled) OnSprintEnd?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la houe du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseHoe(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        if (context.performed) OnHoe?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de l'arrosoir du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseWateringCan(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        if (context.performed) OnWateringCan?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la faux du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseScythe(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        if (context.performed) OnScythe?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la pelle du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseShovel(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        if (context.performed) OnShovel?.Invoke();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        //if (!enabled) return;

        if (context.performed) OnPause?.Invoke();
    }
}
