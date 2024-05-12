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

    /// <summary>
    /// renvoie true si l'objet absorbé est celui désiré
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    protected virtual bool CanAbsorb(Item item)
    {
        return true;
    }

    /// <summary>
    /// appelé lors de l'absorption d'un item
    /// </summary>
    /// <param name="item"></param>
    protected virtual void OnAbsorb(GameObject item) { }

    /// <summary>
    /// appelé lors du contact avec un objet du type référencé dans "CanAbsorb"
    /// </summary>
    /// <param name="item"></param>
    private void Absorb(GameObject item)
    {
        storageContent.Add(item);
        OnAbsorb(item);
    }


}
