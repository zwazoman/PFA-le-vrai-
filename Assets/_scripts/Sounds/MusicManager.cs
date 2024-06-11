using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] float _maxMusicWait = 0f;
    [SerializeField] float _minMusicWait = 5f;

    private void Start()
    {
        TimeManager.Instance.OnMorning += () => StartCoroutine(DayMusic());
        TimeManager.Instance.OnEvening += () => StartCoroutine(NightMusic());
    }

    IEnumerator DayMusic()
    {
        _nightMusicSource.DOFade(0, _fadeDuration);
        _dayMusicSource.volume = _dayVolume;
        AudioClip toSkip = null;
        while (TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minMusicWait,_maxMusicWait));
            if (!TimeManager.Instance.IsDay) break;
            if (PickRandomClip(_dayMusics) == null) yield return 0;
            AudioClip randClip = PickRandomClip(_dayMusics);
            while(randClip == toSkip)
            {
                randClip = PickRandomClip(_dayMusics);
            }
            toSkip = randClip;
            _dayMusicSource.clip = randClip;
            _dayMusicSource.Play();
            yield return new WaitForSeconds(randClip.length);
        }
    }

    IEnumerator NightMusic()
    {
        _dayMusicSource.DOFade(0, _fadeDuration);
        _nightMusicSource.volume = _nightVolume;
        AudioClip toSkip = null;
        while (!TimeManager.Instance.IsDay)
        {
            yield return new WaitForSeconds(Random.Range(_minMusicWait, _maxMusicWait));
            if (TimeManager.Instance.IsDay) break;
            if (PickRandomClip(_nightMusics) == null) yield return 0;
            AudioClip randClip = PickRandomClip(_nightMusics);
            while (randClip == toSkip)
            {
                randClip = PickRandomClip(_dayMusics);
            }
            toSkip = randClip;
            _nightMusicSource.clip = randClip;
            _nightMusicSource.Play();
            yield return new WaitForSeconds(randClip.length);
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
        if (musicList.Length == 0) return null;
        int rand = Random.Range(0, musicList.Length);
        return musicList[rand];
    }
}
