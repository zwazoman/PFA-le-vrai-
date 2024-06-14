using UnityEngine;
using UnityEngine.Rendering;

public class EndSequence : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] Transform _haut;
    [SerializeField] Transform _bas;
    [SerializeField] Volume _volume;
    [SerializeField] AudioSource _sound;
    float yBas => _bas.position.y;
    float yHaut => _haut.position.y;

    [Header("Valeurs")]
    [SerializeField] float _zoomPower;
    [SerializeField] AnimationCurve _volumeCurve;
    [SerializeField] AnimationCurve _soundCurve;
    [SerializeField] AnimationCurve _mainVolumeCurve;

    float baseVolume;


    private void ApplyVisual(float value)
    {

        CameraBehaviour.Instance.zoom = value * _zoomPower;
        _volume.weight = _volumeCurve.Evaluate(value);
        _sound.volume = _soundCurve.Evaluate(value);
        AudioMixerManager.instance.SetMasterVolume(Mathf.Lerp(baseVolume,0,_mainVolumeCurve.Evaluate(value)));

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            float value = other.transform.position.y;
            value = Mathf.Clamp(value, yBas, yHaut);

            value -= yBas;
            value /= (yHaut- yBas);

            ApplyVisual(value);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiManager.Instance.HideEverything();
            _sound.Play();
            baseVolume = AudioMixerManager.instance.GetMasterVolume();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ApplyVisual(0);
            UiManager.Instance.ActivateGameplayPanel();
            _sound.Stop();
        }
    }

    private void Update()
    {
        Debug.DrawLine(_bas.position, _haut.position, Color.red);
    }

    private void Start()
    {
        baseVolume = AudioMixerManager.instance.GetMasterVolume();
        ApplyVisual(0);
    }

}
