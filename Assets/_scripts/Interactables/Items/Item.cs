using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ItemJump))]
/// <summary>
/// permet au joueur de rammasser l'objet dans ses mains
/// h�rite de la classe "Interactable"
/// </summary>
public class Item : Interactable
{
    public Vector3 pickUpRotation;
    /// <summary>
    /// appelle la fonction "Pickup" de la classe "PlayerHands"
    /// </summary>
    protected override void Interaction()
    {
        PlayerMain.Instance.Hands.Pickup(this);
    }

    private void Start()
    {
        TimeManager.Instance.OnDay += DistanceCull;
    }

    public virtual void Jump()
    {
        GetComponent<ItemJump>().Jump();
    }
    
    protected void DistanceCull()
    {
        if ((transform.position - PlayerMain.Instance.transform.position).sqrMagnitude > 35 * 35) Destroy(gameObject); 
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        TimeManager.Instance.OnDay-=DistanceCull;
    }
}
