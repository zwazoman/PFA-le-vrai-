using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerInputManager _inputManager;

    [HideInInspector] public List<Interactable> interactables = new List<Interactable>();



    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnInteract += Interact;
    }

    private void Interact()
    {
        if (interactables.Count == 0f) return;
        float min = -1;
        Interactable closest = null;
        foreach(Interactable interactable in interactables)
        {
            Vector3 distance = interactable.gameObject.transform.position - transform.position;
            if (distance.sqrMagnitude < min || closest == null) 
            {
                min = distance.sqrMagnitude;
                closest = interactable;
            }
        }
        closest.InteractWith();
    }
}
