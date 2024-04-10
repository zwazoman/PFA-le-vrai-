using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

/// <summary>
/// g�re les inputs du joueur
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    public Vector2 moveInput { get; private set; } //valeur de d�placement
    // event interaction du joueur
    public event Action OnInteract;
    // event d�but de la course du joueur
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

    /// <summary>
    /// g�re les inputs de mouvements du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// g�re les input des int�ractions du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            OnInteract?.Invoke();
        }
    }

    /// <summary>
    /// g�re les input du sprint du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed) OnSprintStart?.Invoke();
        if (context.canceled) OnSprintEnd?.Invoke();
    }

    /// <summary>
    /// g�re les inputs de l'utilisation de la houe du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseHoe(InputAction.CallbackContext context)
    {
        if (context.performed) OnHoe?.Invoke();
    }

    /// <summary>
    /// g�re les inputs de l'utilisation de l'arrosoir du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseWateringCan(InputAction.CallbackContext context)
    {
        if (context.performed) OnWateringCan?.Invoke();
    }

    /// <summary>
    /// g�re les inputs de l'utilisation de la faux du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseScythe(InputAction.CallbackContext context)
    {
        if (context.performed) OnScythe?.Invoke();
    }

    /// <summary>
    /// g�re les inputs de l'utilisation de la pelle du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseShovel(InputAction.CallbackContext context)
    {
        if (context.performed) OnShovel?.Invoke();
    }
}
