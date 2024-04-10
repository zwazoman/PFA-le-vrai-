using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnInteract += Drop;
        _interaction = PlayerMain.Instance.Interaction;
    }

    /// <summary>
    /// g�re le rammassage des objets de type "items" : les colle aux mains et d�sactive sa physique et ses collisions change le parent a ce gameObject
    /// </summary>
    /// <param name="item"></param>
    public void Pickup(GameObject item)
    {
        ItemInHands = item;
        _itemInHandsRb = ItemInHands.GetComponent<Rigidbody>(); 
        _iteminHandsColl = ItemInHands.GetComponent<Collider>(); 
        _iteminHandsColl.enabled = false; // d�sactive collider
        _itemInHandsRb.constraints = RigidbodyConstraints.FreezeAll; // freeze l'objet
        ItemInHands.transform.parent = gameObject.transform; // remplace le parent de l'objet par le joueur
        ItemInHands.transform.localPosition = Vector3.forward * _itemDistanceToPlayer; // snap l'objet au joueur
        ItemInHands.transform.rotation = gameObject.transform.rotation; // change la rotation de l'objet par celle du joueur (temporaire ?)
        _grabZone.SetActive(false); // d�sactive la grabzone
        _interaction.enabled = false;
    }

    /// <summary>
    /// g�re le "lachage" de l'objet dans les mains : r�active sa physique et ses collisions, change le parent a null
    /// </summary>
    private void Drop()
    {
        if (ItemInHands == null) return; // ne drop pas si il n'y a rien dans les mains
        ItemInHands.GetComponent<Collider>().enabled = true; // r�active le collider
        _itemInHandsRb.constraints = RigidbodyConstraints.None; // unfreeze l'objet
        ItemInHands.transform.parent = null;
        ItemInHands = null;
        _grabZone.SetActive(true); // r�active la grabzone
        _interaction.enabled = true;
    }
}
