using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : Interactable
{
    [SerializeField] FishingGame _fishingGame;

    protected override void Interaction()
    {
        _fishingGame.StartFishing();
    }
}
