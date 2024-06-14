using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TrompinetteSound : MonoBehaviour
{
    [SerializeField] AudioSource _driveAudioSource;
    [SerializeField] AudioSource _stopAudioSource;

    [SerializeField] AudioClip[] _startEngine;
    [SerializeField] float _startEngineVolume = 1f;

    [SerializeField] AudioClip[] _leaveEngine;
    [SerializeField] float _leaveEngineVolume = 1f;

    WheelBarrowMovement _WBMove;
    float _playerWalkSpeed;

    private void OnEnable()
    {
        _WBMove = PlayerMain.Instance.WheelBarrow.Movement;
        _playerWalkSpeed = PlayerMain.Instance.WheelBarrow.Movement._playerMoveSpeed;
        SFXManager.Instance.PlaySFXClip(_startEngine, transform.position, _startEngineVolume);
        _driveAudioSource.Play();
        _stopAudioSource.Play();
    }

    private void Update()
    {
        _driveAudioSource.volume = _WBMove.Velocity.magnitude / _playerWalkSpeed;
        _stopAudioSource.volume = 1f - (_WBMove.Velocity.magnitude / _playerWalkSpeed) + 0.3f;
     }

    public IEnumerator OnDrop()
    {
        _driveAudioSource.DOFade(0, 0.5f);
        _stopAudioSource.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SFXManager.Instance.PlaySFXClip(_leaveEngine, transform.position, _leaveEngineVolume);
        _driveAudioSource.Stop();
        _stopAudioSource.Stop();
        this.enabled = false;
    }

    private void OnDisable()
    {
        StartCoroutine(OnDrop());
    }


}
