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
           PlantCorruption corrupt = other.GetComponent<PlantCorruption>(); //recupere le component d'un gameobject avec le tag plant

            corrupt._addCorruption *= 2;//multiplie la corruption par 2 
        }
    }
}
