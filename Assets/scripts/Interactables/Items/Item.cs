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
    
    Rigidbody rb;
    protected override void Interaction()
    {
        PlayerMain.Instance.Hands.Pickup(gameObject);
    }

    public virtual void Jump()
    {
        GetComponent<ItemJump>().Jump();
    }

    private void Update()
    {
        if(rb==null) rb=GetComponent<Rigidbody>();
        if ((transform.position - PlayerMain.Instance.transform.position).sqrMagnitude > 35 * 35) rb.Sleep(); else rb.WakeUp();
    }
    /*private void OnDestroy()
    {
        if (PlayerMain.Instance.Interaction.Interactables==this) PlayerMain.Instance.Interaction.Interactables.Remove(this);
    }*/
}
