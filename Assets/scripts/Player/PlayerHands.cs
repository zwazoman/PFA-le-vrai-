using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHands : MonoBehaviour
{
    public GameObject ItemInHands = null;

    [SerializeField] GameObject _grabZone;

    Rigidbody _itemInHandsRb;
    Collider _iteminHandsColl;
    PlayerInputManager _inputManager;


    private void Awake()
    {
        _inputManager = PlayerMain.Instance.InputManager;
    }

    private void Start()
    {
        _inputManager.OnInteract += Drop;
    }

    /// <summary>
    /// gère le rammassage des objets de type "items" : les colle aux mains et désactive sa physique et ses collisions change le parent a ce gameObject
    /// </summary>
    /// <param name="item"></param>
    public void Pickup(GameObject item)
    {
        _grabZone.SetActive(false); // désactive la grabzone
        ItemInHands = item;
        _itemInHandsRb = ItemInHands.GetComponent<Rigidbody>(); 
        _iteminHandsColl = ItemInHands.GetComponent<Collider>(); 
        _iteminHandsColl.enabled = false; // désactive collider
        _itemInHandsRb.detectCollisions = false; // désactive rigidbody
        ItemInHands.transform.parent = gameObject.transform;
        //déplacer dans les mains
    }

    /// <summary>
    /// gère le "lachage" de l'objet dans les mains : réactive sa physique et ses collisions, change le parent a null
    /// </summary>
    public void Drop()
    {
        if (ItemInHands == null) return; // ne drop pas si il n'y a rien dans les mains
        ItemInHands.transform.parent = null;
        ItemInHands.GetComponent<Rigidbody>().detectCollisions = true; // réactive le rigidbody
        ItemInHands.GetComponent<Collider>().enabled = true; // réactive le collider
        _grabZone.SetActive(true); // réactive la grabzone
        ItemInHands = null;
    }
}
