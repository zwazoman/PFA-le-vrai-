using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Storage : MonoBehaviour
{
    protected List<GameObject> storageContent = new List<GameObject>();

    private void Awake()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

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

    protected virtual void OnAbsorb(GameObject item) { }

    private void Absorb(GameObject item)
    {
        storageContent.Add(item);
        item.gameObject.SetActive(false);
        OnAbsorb(item);
        print(item.gameObject.name + " store");
    }


}
