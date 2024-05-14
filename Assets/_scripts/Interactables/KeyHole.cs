using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] List<GameObject> doors = new List<GameObject>();

    public int id = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            if(player.Hands.ItemInHands.TryGetComponent<Key>(out Key key))
            {
                if (key.id != id) return;

                foreach (GameObject go in doors) { if (go.TryGetComponent<door>(out door d)) d.Open(); }

                player.Hands.Drop();
                key.OnUsed();
                Destroy(gameObject);
            }
        }
    }
}
