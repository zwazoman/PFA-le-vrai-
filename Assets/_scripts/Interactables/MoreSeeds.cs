using UnityEngine;

public class MoreSeeds : Interactable
{
    [SerializeField] int _seedsToAdd;

    protected override void Interaction()
    {
        PlayerMain.Instance.Stats.AddSeeds(_seedsToAdd);
    }
}
