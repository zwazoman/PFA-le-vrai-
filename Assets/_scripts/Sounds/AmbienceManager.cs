using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    [SerializeField] float _minTime;
    [SerializeField] float _maxTime;

    [SerializeField] float _sphereSize = 10f;

    [SerializeField] AudioClip[] _ambientEventSounds;
    [SerializeField] float _ambientEventVolume;



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
    }

    private void OnEnable()
    {
        StartCoroutine(PlayAmbientEventSound());
    }

}
