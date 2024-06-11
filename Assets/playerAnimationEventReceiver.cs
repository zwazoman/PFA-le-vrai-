using CustomInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerAnimationEventReceiver : MonoBehaviour
{
    public UnityEvent OnScytheEquip;
    public UnityEvent OnScythe;
    public UnityEvent OnScytheEnd;

    public UnityEvent OnWateringEquip;
    public UnityEvent OnWateringEmptyEquip;
    public UnityEvent OnWatering;
    public UnityEvent OnWateringAction;
    public UnityEvent OnWateringEmpty;
    public UnityEvent OnWateringEnd;

    public UnityEvent OnStopWaterVFX;
    public UnityEvent OnPlayWaterVFX;

    public UnityEvent OnHoeEquip;
    public UnityEvent OnHoeHit;
    public UnityEvent OnHoeEnd;

    //[HorizontalLine("Sons et vfx", 1,FixedColor.DarkGray)]
    public UnityEvent OnWoosh;
    public UnityEvent OnWalkFootstep;
    public UnityEvent OnRunFootstep;

    public UnityEvent OnStopDrinkPotion;

    public void InvokeOnScytheEquip() => OnScytheEquip.Invoke();
    public void InvokeOnScythe() => OnScythe.Invoke();
    public void InvokeOnScytheEnd() => OnScytheEnd.Invoke();

    public void InvokeOnWateringEquip() 
    {
        if (PlayerMain.Instance.Watering.CanWater) OnWateringEquip.Invoke(); else OnWateringEmptyEquip.Invoke();
    }
    public void InvokeOnWatering() => OnWatering.Invoke();
    public void InvokeOnWateringAction()
    {
        if (PlayerMain.Instance.Watering.CanWater) OnWateringAction.Invoke(); else OnWateringEmpty.Invoke();
    } 
    public void InvokeOnWateringEnd() => OnWateringEnd.Invoke();

    public void InvokeHoeEquip() => OnHoeEquip.Invoke();
    public void InvokeOnHoeHit() => OnHoeHit.Invoke();
    public void InvokeOnHoeEnd() => OnHoeEnd.Invoke();

    public void InvokeOnWoosh() => OnWoosh.Invoke();

    public void InvokeOnWalkFootstep() => OnWalkFootstep.Invoke();
    public void InvokeOnRunFootstep() => OnRunFootstep.Invoke();


    public void InvokeOnStopWaterVFX() => OnStopWaterVFX.Invoke();
    public void InvokeOnPlayWaterVFX() 
    {
        if (PlayerMain.Instance.Watering.CanWater) OnPlayWaterVFX.Invoke();
    }

    public void InvokeOnStopDrinkPotion()
    {
        OnStopDrinkPotion.Invoke();
    }

    private void Start()
    {
        InvokeOnStopWaterVFX();
    }
}
