using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrowSounds : MonoBehaviour
{
    AudioSource _wheelBarrowAudioSource;

    private void Awake()
    {
        _wheelBarrowAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnMove += StartWheelBarrowSound;
        PlayerMain.Instance.WheelBarrow.InputManager.OnStop += PauseWheelBarrowSound;
    }

    void StartWheelBarrowSound()
    {
        _wheelBarrowAudioSource.Play();
    }

    void PauseWheelBarrowSound()
    {
        _wheelBarrowAudioSource.Pause();
    }
}
