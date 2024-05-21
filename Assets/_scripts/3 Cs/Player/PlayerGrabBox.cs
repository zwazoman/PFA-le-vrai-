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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Interactable>(out Interactable interactable)&& _interaction.Interactables.Count==0)
        {
            interactable.OnHighlighted();
            //changer un truc sur l'objet interactable pour être explicitement rammassable
            _interaction.Interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<Interactable>(out Interactable interactable))
        {
            if (_interaction.Interactables.Contains(interactable)) 
            {
                interactable.OnStopHighLight();
                // rétablir l'objet interactable pour n'être plus explicitement rammassable
                _interaction.Interactables.Remove(interactable);
            }
        }
    }

    public void ClearHands()
    {
        if(_interaction.Interactables.Count>0) _interaction.Interactables[0].OnStopHighLight();
        _interaction.Interactables.Clear();
    }
}
