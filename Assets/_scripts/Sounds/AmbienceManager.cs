using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    [SerializeField] AudioSource _dayAmbienceAudioSource;
    [SerializeField] AudioSource _nightAmbienceAudioSource;

    [SerializeField] float _minTime;
    [SerializeField] float _maxTime;

    [SerializeField] float _sphereSize = 10f;

    [SerializeField] AudioClip[] _dayAmbientEventSounds;
    [SerializeField] float _dayAmbientEventVolume = 1f;

    [SerializeField] AudioClip[] _nightAmbientEventSounds;
    [SerializeField] float _nightAmbientEventVolume = 1f;

    private void Start()
    {
        TimeManager.Instance.OnMorning += OnEnable;
        TimeManager.Instance.OnEvening += OnDisable;
        StartCoroutine(PlayDayAmbientEventSound());
    }

    IEnumerator PlayDayAmbientEventSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            SFXManager.Instance.PlaySFXClip(_dayAmbientEventSounds, SelectRandomSoundSpot(), _dayAmbientEventVolume);
        }
    }

    IEnumerator PlayNightAmbientEventSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            SFXManager.Instance.PlaySFXClip(_nightAmbientEventSounds, SelectRandomSoundSpot(), _nightAmbientEventVolume);
        }
    }

    Vector3 SelectRandomSoundSpot()
    {
        Vector3 spot = Random.insideUnitSphere * _sphereSize;
        Mathf.Abs(spot.y);
        return transform.position + spot;
    }

    private void OnEnable()
    {
        //StopCoroutine(PlayNightAmbientEventSound());
        StartCoroutine(PlayDayAmbientEventSound());
        _nightAmbienceAudioSource.Pause();
        //_dayAmbienceAudioSource.Play();
    }

    private void OnDisable()
    {
        StopCoroutine(PlayDayAmbientEventSound());
        //StartCoroutine(PlayNightAmbientEventSound());
        _dayAmbienceAudioSource.Pause();
        //_nightAmbienceAudioSource.Play();
    }

}
