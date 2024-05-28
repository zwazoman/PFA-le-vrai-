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

    [SerializeField] AudioClip[] _dayStartSound;
    [SerializeField] float _dayStartSoundVolume = 1f;

    private void Start()
    {
        TimeManager.Instance.OnMorning += DayAmbience;
        TimeManager.Instance.OnEvening += NightAmbience;
        NightAmbience();
    }

    IEnumerator PlayDayAmbience()
    {
        _nightAmbienceAudioSource.Stop();
        _dayAmbienceAudioSource.Play();
        while (TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            if (TimeManager.Instance.IsNight) break;
            SFXManager.Instance.PlaySFXClip(_dayAmbientEventSounds, SelectRandomSoundSpot(), _dayAmbientEventVolume);
        }
    }

    IEnumerator PlayNightAmbience()
    {
        _dayAmbienceAudioSource.Stop();
        _nightAmbienceAudioSource.Play();
        while (TimeManager.Instance.IsNight)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            if (TimeManager.Instance.IsDay) break;
            SFXManager.Instance.PlaySFXClip(_nightAmbientEventSounds, SelectRandomSoundSpot(), _nightAmbientEventVolume);
        }
    }

    Vector3 SelectRandomSoundSpot()
    {
        Vector3 spot = Random.insideUnitSphere * _sphereSize;
        Mathf.Abs(spot.y);
        return transform.position + spot;
    }

    private void DayAmbience()
    {
        print("switch ambience");
        SFXManager.Instance.PlaySFXClip(_dayStartSound, SelectRandomSoundSpot(), _dayStartSoundVolume);
        StopCoroutine(PlayNightAmbience());
        StartCoroutine(PlayDayAmbience());
    }

    private void NightAmbience()
    {
        print("switch ambience");
        StopCoroutine(PlayDayAmbience());
        StartCoroutine(PlayNightAmbience());
    }

    public void EnterInterior()
    {
        StopAllCoroutines();
    }

    public void Exitinterior()
    {
        if (TimeManager.Instance.IsDay) StartCoroutine(PlayDayAmbience()); else StartCoroutine(PlayNightAmbience());
    }

}
