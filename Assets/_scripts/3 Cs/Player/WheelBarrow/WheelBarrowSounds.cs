using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrowSounds : MonoBehaviour
{
    [SerializeField] public AudioSource _wheelBarrowAudioSource;

    private void Update()
    {
        _wheelBarrowAudioSource.volume = PlayerMain.Instance.WheelBarrow.Movement.Velocity.magnitude / PlayerMain.Instance.WheelBarrow.Movement._playerMoveSpeed;
    }

    private void OnEnable()
    {
        _wheelBarrowAudioSource.Play();
    }

    private void OnDisable()
    {
        _wheelBarrowAudioSource.Stop();
    }

    //private void Start()
    //{
    //    PlayerMain.Instance.WheelBarrow.InputManager.OnMove += StartWheelBarrowSound;
    //    PlayerMain.Instance.WheelBarrow.InputManager.OnStop += PauseWheelBarrowSound;
    //}

    //void StartWheelBarrowSound()
    //{
    //    _wheelBarrowAudioSource.Play();
    //}

    //void PauseWheelBarrowSound()
    //{
    //    _wheelBarrowAudioSource.Pause();
    //}
}
