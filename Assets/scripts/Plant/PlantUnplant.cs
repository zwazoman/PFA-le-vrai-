using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantUnplant : MonoBehaviour
{
    [SerializeField] PlantMain _main;

    public void Unplant()
    {
        if (_main.PlantField == null) return;
        //plantMain.gameObject.transform.parent = null; // détache la plante du champ
        _main.PlantField.IsEmpty = true;
        Rigidbody plantRb = _main.gameObject.AddComponent<Rigidbody>(); // ajoute un rigidbody a la plante
        _main.gameObject.AddComponent<Plant>(); // ajoute le component Item a la plante
        _main.Jump.RB = plantRb;
        _main.Jump.Jump(); // fait sauter l'objet
        _main.Corruption.FreezeCorruption();
        _main.PlantField.Plow();
        _main.PlantField = null;
    }
}
