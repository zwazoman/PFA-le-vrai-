using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// gère le ramassage des objets de type "Item" par le joueur
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
    /// gère le rammassage des objets de type "items" : les colle aux mains et désactive sa physique et ses collisions change le parent a ce gameObject
    /// </summary>
    /// <param name="item"></param>
    public void Pickup(GameObject item)
    {
        ItemInHands = item;
        _itemInHandsRb = ItemInHands.GetComponent<Rigidbody>(); 
        _iteminHandsColl = ItemInHands.GetComponent<Collider>(); 
        _iteminHandsColl.enabled = false; // désactive collider
        _itemInHandsRb.constraints = RigidbodyConstraints.FreezeAll; // freeze l'objet
        ItemInHands.transform.parent = gameObject.transform; // remplace le parent de l'objet par le joueur
        ItemInHands.transform.localPosition = Vector3.forward * _itemDistanceToPlayer; // snap l'objet au joueur
        ItemInHands.transform.rotation = gameObject.transform.rotation; // change la rotation de l'objet par celle du joueur (temporaire ?)
        _grabZone.SetActive(false); // désactive la grabzone
        _interaction.enabled = false;
        _tools.canUse = false;
        _inputManager.OnInteract += Drop; // permet au joueur de lacher l'objet en utilisant la touche d'intéraction
    }

    /// <summary>
    /// gère le "lachage" de l'objet dans les mains : réactive sa physique et ses collisions, change le parent a null
    /// </summary>
    private void Drop()
    {
        _iteminHandsColl.enabled = true; // réactive le collider
        _itemInHandsRb.constraints = RigidbodyConstraints.None; // unfreeze l'objet
        ItemInHands.transform.parent = null;
        ItemInHands = null;
        _grabZone.SetActive(true); // réactive la grabzone
        _interaction.enabled = true;
        _tools.canUse = true;
        _inputManager.OnInteract -= Drop; // retire la possibilité de lacher un objet lorsqu'il vient d'en lacher un (car il a les mains vides)
    }
}
