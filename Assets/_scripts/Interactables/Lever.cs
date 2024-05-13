using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] Mill _mill;
    protected override void Interaction()
    {
        //animation de con
        _mill.Crush();
    }
}
