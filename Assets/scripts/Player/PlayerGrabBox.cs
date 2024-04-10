using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gère la détection des objets de type "Interactable" par le joueur
/// </summary>
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
            //changer un truc sur l'objet interactable pour être explicitement rammassable
            _interaction.Interactables.Add(interactable);
            print("ajouter " + interactable.gameObject.name) ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
        {
            if (_interaction.Interactables.Contains(interactable)) 
            {
                // rétablir l'objet interactable pour n'être plus explicitement rammassable
                _interaction.Interactables.Remove(interactable);
                print("retirer " + interactable.gameObject.name);
            }
        }
    }
}
