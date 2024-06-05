using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource _SFXObject;

    //singleton
    private static SFXManager instance = null;
    public static SFXManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip[] audioClips, Vector3 position, float volume, bool bypassesReverb = false, float pitch = 1f)
    {
        if (audioClips.Length == 0) return;
        int rand = Random.Range(0, audioClips.Length);
        AudioSource audioSource = Instantiate(_SFXObject, position, Quaternion.identity);
        audioSource.clip = audioClips[rand];
        audioSource.volume = volume;
        if (bypassesReverb) audioSource.bypassReverbZones = true;
        audioSource.pitch = pitch;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

}
