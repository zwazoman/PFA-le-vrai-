using UnityEngine;

/// <summary>
/// g�re le ramassage des objets de type "Item" par le joueur
/// </summary>
public class PlayerHands : MonoBehaviour
{
    [HideInInspector] public GameObject ItemInHands = null;

    [SerializeField] GameObject _grabZone;
    [SerializeField] float _itemDistanceToPlayer;

    Rigidbody _itemInHandsRb;
    Collider _iteminHandsColl;
    PlayerInputManager _inputManager;
    PlayerInteraction _interaction;
    PlayerTools _tools;

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _interaction = PlayerMain.Instance.Interaction;
        _tools = PlayerMain.Instance.Tools;
    }

    /// <summary>
    /// g�re le rammassage des objets de type "items" : les colle aux mains et d�sactive sa physique et ses collisions change le parent a ce gameObject
    /// </summary>
    /// <param name="item"></param>
    public void Pickup(Item item)
    {
        ItemInHands = item.gameObject;
        _itemInHandsRb = ItemInHands.GetComponent<Rigidbody>(); 
        _iteminHandsColl = ItemInHands.GetComponent<Collider>(); 

        _iteminHandsColl.enabled = false; // d�sactive collider
        _itemInHandsRb.constraints = RigidbodyConstraints.FreezeAll; // freeze l'objet
        ItemInHands.transform.parent = gameObject.transform; // remplace le parent de l'objet par le joueur
        ItemInHands.transform.position = PlayerMain.Instance.GrabBox.transform.position; // snap l'objet au joueur
        ItemInHands.transform.localRotation= Quaternion.Euler(item.pickUpRotation); // change la rotation de l'objet par celle du joueur (temporaire ?)

        _grabZone.SetActive(false); // d�sactive la grabzone
        _interaction.enabled = false;
        _tools.canUse = false;

        PlayerMain.Instance.Sounds.PlayPickupPopSound();

        _inputManager.OnInteract += Drop; // permet au joueur de lacher l'objet en utilisant la touche d'int�raction
    }

    /// <summary>
    /// g�re le "lachage" de l'objet dans les mains : r�active sa physique et ses collisions, change le parent a null
    /// </summary>
    public void Drop()
    {
        _iteminHandsColl.enabled = true; // r�active le collider
        _itemInHandsRb.constraints = RigidbodyConstraints.None; // unfreeze l'objet
        ItemInHands.transform.parent = null;
        ItemInHands.GetComponent<Rigidbody>().AddForce(Vector3.down*10,ForceMode.Impulse);
        ItemInHands = null;
        _grabZone.SetActive(true); // r�active la grabzone
        _interaction.enabled = true;
        _tools.canUse = true;

        PlayerMain.Instance.Sounds.PlayDropPopSound();

        _inputManager.OnInteract -= Drop; // retire la possibilit� de lacher un objet lorsqu'il vient d'en lacher un (car il a les mains vides)
    }
}
