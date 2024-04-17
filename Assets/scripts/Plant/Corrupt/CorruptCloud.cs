using UnityEngine;

/// <summary>
/// Parametre le nuage de corruption
/// </summary>
public class CorruptCloud : MonoBehaviour
{
    private void OnTriggerStay(Collider other) //si une graine est dans le collider du nuages alors sa corruption augmente x2
    {
        if (other.tag == "Plant")
        {
           PlantCorruption corrupt = other.GetComponent<PlantCorruption>();

            corrupt._addCorruption *= 2;
        }
    }
}
