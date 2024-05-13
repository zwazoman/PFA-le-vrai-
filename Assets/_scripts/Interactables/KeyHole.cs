using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField] List<GameObject> doors = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            foreach (GameObject go in doors) { go.SetActive(false); }
            Debug.Log("Key");
        }
    }
}
