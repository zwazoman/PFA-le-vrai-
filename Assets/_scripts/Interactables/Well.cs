using System;
using UnityEngine;

public class Well : Interactable
{
    [SerializeField] AudioClip[] _wellSounds;
    [SerializeField] float _wellSoundsVolume = 1f;

    protected override void Interaction()
    {
        SFXManager.Instance.PlaySFXClip(_wellSounds, transform.position, _wellSoundsVolume);
        PlayerMain.Instance.Watering.Replenish();
    }
}
