using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ItemJump))]
/// <summary>
/// permet au joueur de rammasser l'objet dans ses mains
/// hérite de la classe "Interactable"
/// </summary>
public class Item : Interactable
{
    /// <summary>
    /// appelle la fonction "Pickup" de la classe "PlayerHands"
    /// </summary>
    protected override void Interaction()
    {
        PlayerMain.Instance.Hands.Pickup(gameObject);
    }

    private void Start()
    {
        TimeManager.Instance.OnDay += Despawn;
    }

    public virtual void Jump()
    {
        GetComponent<ItemJump>().Jump();
    }
    
    protected void Despawn()
    {
        if ((transform.position - PlayerMain.Instance.transform.position).sqrMagnitude > 35 * 35) Destroy(gameObject); 
    }
}
