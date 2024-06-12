using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrompinetteSound : MonoBehaviour
{
    [SerializeField] AudioSource _driveAudioSource;
    [SerializeField] AudioSource _stopAudioSource;

    [SerializeField] AudioClip[] _startEngine;
    [SerializeField] float _startEngineVolume;

    [SerializeField] AudioClip[] _leaveEngine;
    [SerializeField] float _leaveEngineVolume;

    Rigidbody _playerRB;
    float _playerWalkSpeed;

    private void Start()
    {
        _playerRB = PlayerMain.Instance.GetComponent<Rigidbody>();
        _playerWalkSpeed = PlayerMain.Instance.Stats.WalkSpeed;
    }

    private void Update()
    {
        _driveAudioSource.volume = _playerRB.velocity.magnitude / _playerWalkSpeed;
        _stopAudioSource.volume = 1f - (_playerRB.velocity.magnitude / _playerWalkSpeed);
     }

    public void OnPickUp()
    {
        SFXManager.Instance.PlaySFXClip(_startEngine, transform.position, _startEngineVolume);
        _driveAudioSource.Play();
        _stopAudioSource.Play();
    }

    public void OnDrop()
    {
        SFXManager.Instance.PlaySFXClip(_leaveEngine, transform.position, _leaveEngineVolume);
        _driveAudioSource.Stop();
        _stopAudioSource.Stop();
    }


}
