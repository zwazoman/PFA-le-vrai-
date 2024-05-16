using System;
using UnityEngine;

public class Well : Interactable
{
    [SerializeField] WellSounds _wellSounds;

    protected override void Interaction()
    {
        PlayerMain.Instance.Watering.Replenish();
        _wellSounds.PlayWellSound();
    }
}
