using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] _toolsWooshes;
    [SerializeField] float _toolsWooshesVolume = 1f;

    [Header("Hoe")]
    [SerializeField] AudioClip[] _hoeEquip;
    [SerializeField] float _hoeEquipVolume = 1f;

    [Header("Watering Can")] 
    [SerializeField] AudioClip[] _wateringCanEquip;
    [SerializeField] float _wateringCanEquipVolume = 1f;

    [SerializeField] AudioClip[] _wateringAction;
    [SerializeField] float _wateringActionVolume = 1f;

    [Header("Scythe")]
    [SerializeField] AudioClip[] _scytheEquip;
    [SerializeField] float _scytheEquipVolume = 1f;

    [Header("Footsteps")]
    [SerializeField] AudioClip[] _walkFootsteps;
    [SerializeField] float _walkFootstepsVolume = 1f;

    [SerializeField] AudioClip[] _runFootsteps;
    [SerializeField] float _runFootstepsVolume = 1f;

    public void PlayWateringActionSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringAction, transform, _wateringActionVolume);
    }
    public void PlayToolsWooshSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolsWooshes, transform, _toolsWooshesVolume);
    }

    public void PlayHoeEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_hoeEquip, transform, _hoeEquipVolume);
    }

    public void PlayWateringCanEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_wateringCanEquip, transform, _wateringCanEquipVolume);
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

}
