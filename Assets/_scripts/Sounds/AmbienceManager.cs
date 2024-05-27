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
    }

    IEnumerator PlayDayAmbience()
    {
        _nightAmbienceAudioSource.Pause();
        _dayAmbienceAudioSource.Play();
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            SFXManager.Instance.PlaySFXClip(_dayAmbientEventSounds, SelectRandomSoundSpot(), _dayAmbientEventVolume);
        }
    }

    IEnumerator PlayNightAmbience()
    {
        _dayAmbienceAudioSource.Pause();
        _nightAmbienceAudioSource.Play();
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
        StopCoroutine(PlayNightAmbience());
        StartCoroutine(PlayDayAmbience());
    }

    private void OnDisable()
    {
        StopCoroutine(PlayDayAmbience());
        StartCoroutine(PlayNightAmbience());
    }

}
