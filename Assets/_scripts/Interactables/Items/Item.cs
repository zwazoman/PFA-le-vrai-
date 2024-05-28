using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ItemJump))]
/// <summary>
/// permet au joueur de rammasser l'objet dans ses mains
/// hérite de la classe "Interactable"
/// </summary>
public class Item : Interactable
{
    [field : SerializeField]
    public string Name { get; private set; }

    public Vector3 pickUpRotation;

    ItemJump _itemJump;
    ItemTag _itemTag;

    private void Awake()
    {
        _itemJump = GetComponent<ItemJump>();
        _itemTag = GetComponent<ItemTag>();
    }


    /// <summary>
    /// appelle la fonction "Pickup" de la classe "PlayerHands"
    /// </summary>
    protected override void Interaction()
    {
        PlayerMain.Instance.Hands.Pickup(this);
    }

    public virtual void Drop() { }

    public virtual void Jump()
    {
        _itemJump.Jump();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        //TimeManager.Instance.OnDay-=DistanceCull;
    }
}
