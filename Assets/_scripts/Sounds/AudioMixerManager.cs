using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;

    public void SetMasterVolume(float level)
    {
        _mixer.SetFloat("masterVolume", level);
    }

    public void SetSFXVOlume(float level)
    {
        _mixer.SetFloat("masterVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        _mixer.SetFloat("masterVolume", level);
    }
}
