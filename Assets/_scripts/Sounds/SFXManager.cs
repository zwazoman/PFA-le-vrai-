using System.Threading.Tasks;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] Pool _audioSourcePool;

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

    public async void PlaySFXClip(AudioClip[] audioClips, Vector3 position, float volume, bool bypassesReverb = false, bool ignoresSpatiality = false, float pitch = 1f)
    {
        if (audioClips.Length == 0) return;
        int rand = Random.Range(0, audioClips.Length);

        PooledObject o = _audioSourcePool.PullObjectFromPool(transform);
        AudioSource audioSource = (AudioSource)o.fetchMainComponent<AudioSource>();//Instantiate(_SFXObject, position, Quaternion.identity);
        audioSource.clip = audioClips[rand];
        audioSource.volume = volume;
        if (bypassesReverb) audioSource.bypassReverbZones = true;
        if (ignoresSpatiality) audioSource.spatialBlend = 0;
        audioSource.pitch = pitch;
        audioSource.Play();
        float clipLength = audioSource.clip.length;

        await Task.Delay(Mathf.CeilToInt(clipLength * 1000));

        _audioSourcePool.PutObjectBackInPool(o);
        //Destroy(audioSource.gameObject, clipLength);
    }

}
