using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    [SerializeField] AudioSource _ambienceAudioSource;

    [SerializeField] float _minTime;
    [SerializeField] float _maxTime;

    [SerializeField] float _sphereSize = 10f;

    [SerializeField] AudioClip[] _ambientEventSounds;
    [SerializeField] float _ambientEventVolume = 1f;
    private void Start()
    {
        StartCoroutine(PlayAmbientEventSound());
    }

    IEnumerator PlayAmbientEventSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            SFXManager.Instance.PlaySFXClip(_ambientEventSounds, SelectRandomSoundSpot(), _ambientEventVolume);
        }
    }

    Vector3 SelectRandomSoundSpot()
    {
        Vector3 spot = Random.insideUnitSphere * _sphereSize;
        Mathf.Abs(spot.y);
        return transform.position + spot;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        _ambienceAudioSource.Pause();
    }

    private void OnEnable()
    {
        StartCoroutine(PlayAmbientEventSound());
        _ambienceAudioSource.Play();
    }

}
