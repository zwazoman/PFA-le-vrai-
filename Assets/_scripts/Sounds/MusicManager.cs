using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Day")]
    [SerializeField] AudioSource _dayMusicSource;
    [SerializeField] AudioClip[] _dayMusics;

    [Header("Night")]
    [SerializeField] AudioSource _nightMusicSource;
    [SerializeField] AudioClip[] _nightMusics;

    [Header("Volumes")]
    [SerializeField] float _dayVolume = 1f;
    [SerializeField] float _nightVolume = 1f;

    [Header("Chien")]
    [SerializeField] float _fadeDuration = 1f;
    [SerializeField] float _musicWait = 1f;

    private void Awake()
    {
        StartCoroutine(ActivateDayMusics());
        StartCoroutine(ActivateNightMusic());
    }

    private void Start()
    {
        TimeManager.Instance.OnMorning += () => StartCoroutine(PlayDayMusic());
        //TimeManager.Instance.OnEvening += () => StartCoroutine(PlayNightMusic());
    }

    IEnumerator PlayDayMusic()
    {
        _nightMusicSource.DOFade(0, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration);
        _dayMusicSource.DOFade(_dayVolume, _fadeDuration);
    }

    IEnumerator PlayNightMusic()
    {
        _dayMusicSource.DOFade(0, _fadeDuration);
        yield return new WaitForSeconds(_fadeDuration);
        _nightMusicSource.DOFade(_nightVolume, _fadeDuration);
    }

    IEnumerator ActivateDayMusics()
    {
        while (true)
        {
            _dayMusicSource.clip = PickRandomClip(true);
            _dayMusicSource.Play();
            yield return new WaitForSeconds(_dayMusicSource.clip.length + _musicWait);
        }
    }

    IEnumerator ActivateNightMusic()
    {
        while (true)
        {
            _nightMusicSource.clip = PickRandomClip(false);
            _nightMusicSource.Play();
            yield return new WaitForSeconds(_nightMusicSource.clip.length + _musicWait);
        }
    }

    AudioClip PickRandomClip(bool day)
    {
        if (day)
        {
            int rand = Random.Range(0, _dayMusics.Length);
            return _dayMusics[rand];
        }
        else
        {
            int rand = Random.Range(0, _nightMusics.Length);
            return _nightMusics[rand];
        }
    }

}
