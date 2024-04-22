using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructStorage : Storage
{
    [SerializeField] GameObject _fieldPrefab;
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Title);
    }

    protected override void OnAbsorb(GameObject item)
    {
        Instantiate(_fieldPrefab, transform.position, transform.rotation);
        Destroy(item);
        Destroy(gameObject);
    }
}
