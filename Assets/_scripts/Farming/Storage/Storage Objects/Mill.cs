using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mill : MonoBehaviour
{
    List<Collider> _collList = new List<Collider>();
    [SerializeField] UnityEvent OnCrush;

    [Header("Sounds")]
    [SerializeField] AudioClip[] _crushSound;
    [SerializeField] float _crushSoundVolume = 1f;

    [SerializeField] AudioClip[] _rechargeSound;
    [SerializeField] float _rechargeSoundVolume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Breakable>(out Breakable breakable))
        {
            _collList.Add(other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (_collList.Contains(other)) _collList.Remove(other);
    }

    /// <summary>
    /// casse les objets dans le moulin
    /// </summary>
    public void Crush()
    {
        StartCoroutine(PlaySounds());
        OnCrush.Invoke();
        foreach (Collider coll in _collList)
        {
            coll.gameObject.GetComponent<Breakable>().SetBreak(coll.gameObject.GetComponent<Breakable>().maxhp);
        }
        _collList.Clear();
    }

    IEnumerator PlaySounds()
    {
        SFXManager.Instance.PlaySFXClip(_crushSound, transform, _crushSoundVolume);
        yield return new WaitForSeconds(0.5f);
        SFXManager.Instance.PlaySFXClip(_rechargeSound, transform, _rechargeSoundVolume);
    }
}
