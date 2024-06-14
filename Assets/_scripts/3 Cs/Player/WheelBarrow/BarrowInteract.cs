using UnityEngine;

public class BarrowInteract : Interactable
{
    [SerializeField] WheelBarrowStorage _storage;
    protected override void Interaction()
    {
        _storage.EmptyInHands();
    }
}
