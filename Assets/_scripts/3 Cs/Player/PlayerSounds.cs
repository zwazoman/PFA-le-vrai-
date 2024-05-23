using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Hoe")]
    [SerializeField] AudioClip[] _hoeEquip;
    [SerializeField] float _hoeEquipVolume = 1f;

    [Header("Watering Can")] 
    [SerializeField] AudioClip[] _wateringCanEquip;
    [SerializeField] float _wateringCanEquipVolume = 1f;

    [SerializeField] AudioClip[] _wateringCanEmptyEquip;
    [SerializeField] float _wateringCanEmptyEquipVolume = 1f;

    [SerializeField] AudioClip[] _wateringAction;
    [SerializeField] float _wateringActionVolume = 1f;

    [SerializeField] AudioClip[] _wateringEmpty;
    [SerializeField] float _wateringEmptyVolume = 0.2f;

    [Header("Scythe")]
    [SerializeField] AudioClip[] _scytheEquip;
    [SerializeField] float _scytheEquipVolume = 1f;

    [Header("Footsteps")]
    [SerializeField] AudioClip[] _walkFootsteps;
    [SerializeField] float _walkFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _runFootsteps;
    [SerializeField] float _runFootstepsVolume = 1f;

    [Header("Wooshes")]
    [SerializeField] AudioClip[] _toolWoosh;
    [SerializeField] float _toolWooshVolume = 1f;

    [Header("Pops")]
    [SerializeField] AudioClip[] _pickupPop;
    [SerializeField] float _pickupPopVolume = 1f;

    [SerializeField] AudioClip[] _dropPop;
    [SerializeField] float _dropPopSound = 1f;


    public void PlayToolWooshSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolWoosh, transform, _toolWooshVolume);
    }


    public void PlayHoeEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_hoeEquip, transform, _hoeEquipVolume);
    }


    public void PlayWateringCanEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEquip, transform, _wateringCanEquipVolume);
    }

    public void PlayWateringCanEmptyEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEmptyEquip, transform, _wateringCanEmptyEquipVolume);
    }

    public void PlayWateringActionSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringAction, transform, _wateringActionVolume);
    }

    public void PlayWateringEmpty()
    {
        SFXManager.Instance.PlaySFXClip(_wateringEmpty, transform, _wateringEmptyVolume);
    }

    public void PlayScytheEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_scytheEquip, transform, _scytheEquipVolume);
    }


    public void PlayWalkFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_walkFootsteps, transform, _walkFootstepsVolume);
    }

    public void PlayRunFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_runFootsteps, transform, _runFootstepsVolume);
    }


    public void PlayPickupPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_pickupPop, transform, _pickupPopVolume);
    }

    public void PlayDropPopSound()
    {
        SFXManager.Instance.PlaySFXClip(_dropPop, transform, _dropPopSound);
    }

}
