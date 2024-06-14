using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    bool _isInterior = false;

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
        TimeManager.Instance.OnMorning += DayStartAmbience;
        TimeManager.Instance.OnEvening += NightStartAmbience;
        NightStartAmbience();
    }

    IEnumerator PlayDayAmbience()
    {
        _nightAmbienceAudioSource.Stop();
        _dayAmbienceAudioSource.Play();
        while (TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            if (!TimeManager.Instance.IsDay || _isInterior) break;
            SFXManager.Instance.PlaySFXClip(_dayAmbientEventSounds, SelectRandomSoundSpot(), _dayAmbientEventVolume);
        }
    }

    IEnumerator PlayNightAmbience()
    {
        _dayAmbienceAudioSource.Stop();
        _nightAmbienceAudioSource.Play();
        while (!TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            if (TimeManager.Instance.IsDay || _isInterior) break;
            SFXManager.Instance.PlaySFXClip(_nightAmbientEventSounds, SelectRandomSoundSpot(), _nightAmbientEventVolume);
        }
    }

    Vector3 SelectRandomSoundSpot()
    {
        Vector3 spot = Random.insideUnitSphere * _sphereSize;
        Mathf.Abs(spot.y);
        return transform.position + spot;
    }

    private void DayStartAmbience()
    {
        SFXManager.Instance.PlaySFXClip(_dayStartSound, SelectRandomSoundSpot(), _dayStartSoundVolume, false);
        StopCoroutine(PlayNightAmbience());
        StartCoroutine(PlayDayAmbience());
    }

    private void NightStartAmbience()
    {
        StopCoroutine(PlayDayAmbience());
        StartCoroutine(PlayNightAmbience());
    }

    public void EnterInterior()
    {
        print("INTERIEUR");
        _isInterior = true;
        StopCoroutine(PlayDayAmbience());
        StopCoroutine(PlayNightAmbience());
        _nightAmbienceAudioSource.Stop();
        _dayAmbienceAudioSource.Stop();
    }

    public void Exitinterior()
    {
        print("EXTERIEUR");
        _isInterior = false;
        if (TimeManager.Instance.IsDay) StartCoroutine(PlayDayAmbience()); else StartCoroutine(PlayNightAmbience());
    }

}
