using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerAnimationEventReceiver : MonoBehaviour
{
    public UnityEvent OnScythe;
    public UnityEvent OnScytheEnd;
    
    public UnityEvent OnWatering;
    public UnityEvent OnWateringEnd;

    public UnityEvent OnHoeHit;
    public UnityEvent OnHoeEnd;


    public void InvokeOnScythe() => OnScythe.Invoke();
    public void InvokeOnScytheEnd() => OnScytheEnd.Invoke();

    public void InvokeOnWatering() => OnWatering.Invoke();
    public void InvokeOnWateringEnd() => OnWateringEnd.Invoke();

    public void InvokeOnHoeHit() => OnHoeHit.Invoke();
    public void InvokeOnHoeEnd() => OnHoeEnd.Invoke();

}
