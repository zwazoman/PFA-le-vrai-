using UnityEngine;

public class HandlesInteract : Interactable
{
    [SerializeField] WheelBarrowHandles _handles;
    protected override void Interaction()
    {
        _handles.Equip();
    }
}
