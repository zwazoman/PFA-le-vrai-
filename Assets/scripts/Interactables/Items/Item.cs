using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// permet au joueur de rammasser l'objet dans ses mains
/// hérite de la classe "Interactable"
/// </summary>
public class Item : Interactable
{
    /// <summary>
    /// appelle la fonction "Pickup" de la classe "PlayerHands"
    /// </summary>
    public override void InteractWith()
    {
        PlayerMain.Instance.Hands.Pickup(gameObject);
    }

    private void OnDestroy()
    {
        if (PlayerMain.Instance.Interaction.Interactables.Contains(this)) PlayerMain.Instance.Interaction.Interactables.Remove(this);
    }
}
