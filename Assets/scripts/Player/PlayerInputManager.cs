using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputManager : MonoBehaviour
{
    // event mouvements du joueur
    public event Action OnMove;
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

    /// <summary>
    /// gère les inputs de mouvements du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        
    }

    /// <summary>
    /// gère les input des intéractions du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed) OnInteract?.Invoke();
    }

    /// <summary>
    /// gère les input du sprint du joueur
    /// </summary>
    /// <param name="context"></param>
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed) OnSprintStart?.Invoke();
        if (context.canceled) OnSprintEnd?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la houe du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseHoe(InputAction.CallbackContext context)
    {
        if (context.performed) OnHoe?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de l'arrosoir du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseWateringCan(InputAction.CallbackContext context)
    {
        if (context.performed) OnWateringCan?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la faux du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseScythe(InputAction.CallbackContext context)
    {
        if (context.performed) OnScythe?.Invoke();
    }

    /// <summary>
    /// gère les inputs de l'utilisation de la pelle du joueur
    /// </summary>
    /// <param name="context"></param>
    public void UseShovel(InputAction.CallbackContext context)
    {
        if (context.performed) OnShovel?.Invoke();
    }
}
