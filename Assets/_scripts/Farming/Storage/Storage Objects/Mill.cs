using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mill : MonoBehaviour
{
    List<Collider> _collList = new List<Collider>();
    [SerializeField] UnityEvent OnCrush;

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
        OnCrush.Invoke();
        foreach (Collider coll in _collList)
        {
            coll.gameObject.GetComponent<Breakable>().SetBreak(coll.gameObject.GetComponent<Breakable>().maxhp);
        }
        _collList.Clear();
    }
}
