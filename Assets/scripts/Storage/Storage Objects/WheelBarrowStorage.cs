using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WheelBarrowStorage : Storage
{
    [field : SerializeField] 
    public float _maxStorageWheelBarrow { get; set; }

    [SerializeField] float _distanceToEmpty;
    [SerializeField] float _hightToEmpty;

    private void Start()
    {
        PlayerMain.Instance.WheelBarrow.InputManager.OnEmpty += () => StartCoroutine(Empty());
    }

    protected override bool CanAbsorb(Item item)
    {
        return storageContent.Count <= _maxStorageWheelBarrow;
    }
    protected override void OnAbsorb(GameObject item)
    {
        item.SetActive(false);
        item.transform.parent = transform;
        item.transform.position = transform.position + Vector3.up;
    }

    public IEnumerator Empty()
    {
        for (int i = storageContent.Count - 1; i >= 0; i--)
        {
            storageContent[i].transform.parent = null;
            storageContent[i].transform.position = transform.forward * _distanceToEmpty + Vector3.up * _hightToEmpty;
            storageContent[i].SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
