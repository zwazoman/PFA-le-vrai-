using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] _sploushSounds;
    [SerializeField] float _volume = 1f;
    public void PlayWellSound()
    {
        SFXManager.Instance.PlaySFXClip(_sploushSounds, transform, _volume);
    }
}
