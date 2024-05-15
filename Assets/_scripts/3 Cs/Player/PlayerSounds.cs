using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] _toolsWooshes;
    [SerializeField] AudioClip[] _toolsEquip;
    [SerializeField] AudioClip[] _walkFootsteps;
    [SerializeField] AudioClip[] _runFootsteps;

    public void PlayToolsWooshSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolsWooshes, transform, 1f);
    }

    public void PlayToolEquipSound()
    {
        SFXManager.Instance.PlaySFXClip(_toolsEquip, transform, 1f);
    }

    public void PlayWalkFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_walkFootsteps, transform, 0.5f);
    }

    public void PlayRunFootstepSound()
    {
        SFXManager.Instance.PlaySFXClip(_runFootsteps, transform, 0.5f);
    }

}
