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
<<<<<<< Updated upstream:Assets/scripts/Storage/Storage Objects/ConstructStorage.cs
        Instantiate(_fieldPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
=======
        Instantiate(_fieldPrefab, transform.position, transform.rotation).transform.localScale = transform.localScale;
>>>>>>> Stashed changes:Assets/_scripts/Farming/Storage/Storage Objects/ConstructStorage.cs
        Destroy(item);
        Destroy(gameObject);
    }
}
