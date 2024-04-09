using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBox : MonoBehaviour
{
    PlayerInteraction _interaction;

    private void Awake()
    {
        _interaction = gameObject.transform.parent.GetComponent<PlayerInteraction>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
        {
            print("détecte");
            _interaction.interactables.Add(interactable);
            print("ajouter " + interactable.gameObject.name) ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
        {
            if (_interaction.interactables.Contains(interactable)) 
            {
                _interaction.interactables.Remove(interactable);
                print("retirer " + interactable.gameObject.name);
            }
        }
    }
}
