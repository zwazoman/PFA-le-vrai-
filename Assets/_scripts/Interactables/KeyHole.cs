using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] List<door> doors = new List<door>();

    public int id = -1;

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<PlayerMain>(out PlayerMain player))
        {

            if(player.Hands.ItemInHands!=null && player.Hands.ItemInHands.TryGetComponent<Key>(out Key key))
            {

                if (key.id != id) return;


                foreach (door d in doors) { d.Open(); }


                player.Hands.Drop();
                key.OnUsed();
                Destroy(gameObject);
            }
        }
    }
}
