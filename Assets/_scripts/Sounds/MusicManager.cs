using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    [SerializeField] float _maxMusicWait;
    [SerializeField] float _minMusicWait;

    private void Start()
    {
        TimeManager.Instance.OnMorning += () => StartCoroutine(DayMusic());
        TimeManager.Instance.OnEvening += () => StartCoroutine(NightMusic());
    }

    IEnumerator DayMusic()
    {
        _nightMusicSource.DOFade(0, _fadeDuration);
        _dayMusicSource.volume = _dayVolume;
        while (TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minMusicWait,_maxMusicWait));
            if (!TimeManager.Instance.IsDay) break;
            _dayMusicSource.clip = (PickRandomClip(_dayMusics));
            _dayMusicSource.Play();
        }
    }

    IEnumerator NightMusic()
    {
        _dayMusicSource.DOFade(0, _fadeDuration);
        _nightMusicSource.volume = _nightVolume;
        while (!TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minMusicWait, _maxMusicWait));
            if (TimeManager.Instance.IsDay) break;
            _nightMusicSource.clip = (PickRandomClip(_nightMusics));
            _nightMusicSource.Play();
        }
    }

    void PauseMusic()
    {
        if (TimeManager.Instance.IsDay)
        {
            _dayMusicSource.Pause();
        }
        else
        {
            _nightMusicSource.Pause();
        }
    }

    void ResumeMusic()
    {
        if (TimeManager.Instance.IsDay)
        {
            _dayMusicSource.UnPause();
        }
        else
        {
            _nightMusicSource.UnPause();
        }
    }

    AudioClip PickRandomClip(AudioClip[] musicList)
    {
         int rand = Random.Range(0, musicList.Length);
         return musicList[rand];
    }
}
