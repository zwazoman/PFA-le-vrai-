using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gère les intéractions du joueur avec les objets de type "Interactables"
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    PlayerInputManager _inputManager;

    [HideInInspector] public List<Interactable> Interactables = new List<Interactable>();



    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnInteract += Interact;
    }

    /// <summary>
    /// choisis l'objet le plus proche au sein de la liste "Interactables" et appelle sa fonction "InteractWith"
    /// </summary>
    private void Interact()
    {
        if (Interactables.Count == 0f) return;
        float min = -1;
        Interactable closest = null;
        foreach(Interactable interactable in Interactables)
        {
            Vector3 distance = interactable.gameObject.transform.position - transform.position; // distance entre l'objet et le joueur
            if (distance.sqrMagnitude < min || closest == null) 
            {
                min = distance.sqrMagnitude;
                closest = interactable;
            }
        }
        closest.InteractWith();
    }

    private void OnDisable()
    {
        foreach(Interactable interactable in Interactables)
        {
            interactable.OnStopHighLight();
        }
        Interactables.Clear(); // vide la liste "Interactables" quand le component est désactivé pour éviter de re-ramasser a l'infini un objet en voulant le jeter
    }
}
