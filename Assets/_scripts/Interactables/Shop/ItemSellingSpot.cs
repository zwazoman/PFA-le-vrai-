using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellingSpot : SellingSpot
{
    [SerializeField] Item itemToSell;

    //item floating animation
    Vector3 ItemBasePosition;
    float basePhase;
    public GameObject buttonUI;

    private void Awake()
    {
        foreach (Behaviour b in itemToSell.GetComponents<Behaviour>()) //desactive l'item
        {
            if (b.GetType() != typeof(Renderer) && b.GetType() != typeof(MeshFilter))
            b.enabled = false;
        }

        if(itemToSell.TryGetComponent<Rigidbody>(out Rigidbody rb))rb.isKinematic=true;


        ItemBasePosition = itemToSell.transform.position;
        basePhase = Random.value * 100;


    }
    public override void SellItem()
    {
        base.SellItem();
        SpawnItem();
    }

    private void Update()
    {
        //animation de l'item
        if(TimeManager.Instance.isPaused)
        {
            itemToSell.transform.position = ItemBasePosition + Vector3.up * Mathf.Sin(Time.time * 2+ basePhase) * 0.3f;
            itemToSell.transform.Rotate(Vector3.up, Time.deltaTime * 20,Space.World);
        }
        
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
