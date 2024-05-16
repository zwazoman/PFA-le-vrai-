using CustomInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerAnimationEventReceiver : MonoBehaviour
{
    public UnityEvent OnScythe;
    public UnityEvent OnScytheEnd;
    
    public UnityEvent OnWatering;
    public UnityEvent OnWateringAction;
    public UnityEvent OnWateringEnd;

    public UnityEvent OnHoeHit;
    public UnityEvent OnHoeEnd;

    //[HorizontalLine("Sons et vfx", 1,FixedColor.DarkGray)]
    public UnityEvent OnWoosh;
    public UnityEvent OnToolEquiped;
    public UnityEvent OnWalkFootstep;
    public UnityEvent OnRunFootstep;

    public void InvokeOnScythe() => OnScythe.Invoke();
    public void InvokeOnScytheEnd() => OnScytheEnd.Invoke();

    public void InvokeOnWatering() => OnWatering.Invoke();
    public void InvokeOnWateringAction() => OnWateringAction.Invoke();
    public void InvokeOnWateringEnd() => OnWateringEnd.Invoke();

    public void InvokeOnHoeHit() => OnHoeHit.Invoke();
    public void InvokeOnHoeEnd() => OnHoeEnd.Invoke();

    public void InvokeOnWoosh() => OnWoosh.Invoke();
    public void InvokeOnToolEquiped() => OnToolEquiped.Invoke();

    public void InvokeOnWalkFootstep() => OnWalkFootstep.Invoke();
    public void InvokeOnRunFootstep() => OnRunFootstep.Invoke();

}
