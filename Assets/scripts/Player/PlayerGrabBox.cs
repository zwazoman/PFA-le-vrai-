using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re la d�tection des objets de type "Interactable" par le joueur
/// </summary>
public class PlayerGrabBox : MonoBehaviour
{
    PlayerInteraction _interaction;

    private void Awake()
    {
        _interaction = gameObject.transform.parent.GetComponent<PlayerInteraction>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Interactable>(out Interactable interactable)&& _interaction.Interactables.Count==0)
        {
            print("d�tecte");
            interactable.OnHighlighted();
            //changer un truc sur l'objet interactable pour �tre explicitement rammassable
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
                interactable.OnStopHighLight();
                // r�tablir l'objet interactable pour n'�tre plus explicitement rammassable
                _interaction.Interactables.Remove(interactable);
                print("retirer " + interactable.gameObject.name);
            }
        }
    }

    public void ClearHands()
    {
        _interaction.Interactables[0].OnStopHighLight();
        _interaction.Interactables.Clear();
    }
}
