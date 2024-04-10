using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    protected List<GameObject> storageContent = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.TryGetComponent<Item>(out Item item))
        {
            if (CanAbsorb(item))
            {
                Absorb(item.gameObject);
            }
        }
    }

    protected virtual bool CanAbsorb(Item item)
    {
        return true;
    }

    protected virtual void OnAbsorb() { }

    private void Absorb(GameObject item)
    {
        storageContent.Add(item);
        item.gameObject.SetActive(false);
        print(item.gameObject.name + " store");
    }


}
