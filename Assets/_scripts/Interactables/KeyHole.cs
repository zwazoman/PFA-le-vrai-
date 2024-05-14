using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] List<door> doors = new List<door>();

    public int id = -1;

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.TryGetComponent<PlayerMain>(out PlayerMain player))
        {
            print("La");
            if(player.Hands.ItemInHands!=null && player.Hands.ItemInHands.TryGetComponent<Key>(out Key key))
            {
                print("Calotte");
                if (key.id != id) return;
                print("de tes");

                foreach (door d in doors) { d.Open(); print("Morts"); }

                print("Putain");
                player.Hands.Drop();
                key.OnUsed();
                Destroy(gameObject);
            }
        }
    }
}
