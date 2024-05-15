using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellingSpot : SellingSpot
{
    [SerializeField] Item itemToSell;

    private void Awake()
    {
        foreach (Behaviour b in itemToSell.GetComponents<Behaviour>()) //desactive l'item
        {
            if (b.GetType() != typeof(Renderer) && b.GetType() != typeof(MeshFilter))
            b.enabled = false;
        }

        if(itemToSell.TryGetComponent<Rigidbody>(out Rigidbody rb))rb.isKinematic=true;
        
    }
    public override void SellItem()
    {
        base.SellItem();
        SpawnItem();
    }

    private void SpawnItem()
    {
        if (itemToSell.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.isKinematic = false; 
        foreach (Behaviour b in itemToSell.GetComponents<Behaviour>()) //desactive l'item
        {
            if (b.GetType() != typeof(Renderer) && b.GetType() != typeof(MeshFilter))
                b.enabled = false;
        }


        itemToSell.GetComponent<Item>().Jump();
        Destroy(this);
    }
}
