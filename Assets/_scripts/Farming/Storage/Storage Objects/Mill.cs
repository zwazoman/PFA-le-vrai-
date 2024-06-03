using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

public class Mill : MonoBehaviour
{
    List<Collider> _collList = new List<Collider>();
    [SerializeField] UnityEvent OnCrush;
    [SerializeField] xpSource  vfxSource;

    [Header("SFXs")]
    [SerializeField] AudioClip[] _crushSound;
    [SerializeField] float _crushSoundVolume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Breakable>(out Breakable breakable))
        {
            _collList.Add(other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (_collList.Contains(other)) { _collList.Remove(other); }
        else if (PlayerMain.Instance.Hands.ItemInHands!=null && _collList.Contains(PlayerMain.Instance.Hands.ItemInHands.GetComponent<Collider>())){_collList.Remove(PlayerMain.Instance.Hands.ItemInHands.GetComponent<Collider>());}
    }


    /// <summary>
    /// casse les objets dans le moulin
    /// </summary>
    public async Task Crush()
    {
        SFXManager.Instance.PlaySFXClip(_crushSound, transform.position, _crushSoundVolume);
        RumbleManager.instance.RumblePulse(0.5f, 0.8f, 0.3f);
        OnCrush?.Invoke();
        CameraBehaviour.Instance.zoomEffect(8+2*_collList.Count);
        foreach (Collider coll in _collList)
        {
            if (coll.enabled)
            {
                if (coll.gameObject.GetComponent<Breakable>()) coll.gameObject.GetComponent<Breakable>().Break();
                if (coll.gameObject.transform.root.GetComponentInChildren<Orb>()) { vfxSource.playFX(); }
            }

            await Task.Delay(100);
        }
        _collList.Clear();

    }
}
