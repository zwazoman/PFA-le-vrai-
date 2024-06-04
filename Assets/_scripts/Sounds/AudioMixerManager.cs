using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;

    public void SetMasterVolume(float level)
    {
        _mixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void SetSFXVOlume(float level)
    {
        _mixer.SetFloat("SFXVolume", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVolume(float level)
    {
        _mixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }
}
