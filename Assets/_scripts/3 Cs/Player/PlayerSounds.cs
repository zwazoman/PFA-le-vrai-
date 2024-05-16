using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] _wateringAction;
    [SerializeField] float _wateringActionVolume = 1f;

    [SerializeField] AudioClip[] _toolsWooshes;
    [SerializeField] float _toolsWooshesVolume = 1f;

    [SerializeField] AudioClip[] _toolsEquip;
    [SerializeField] float _toolsEquipVolume = 1f;

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

    public void PlayToolEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolsEquip, transform, _toolsEquipVolume);
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
