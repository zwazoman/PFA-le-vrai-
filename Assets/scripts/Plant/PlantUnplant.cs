using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// gère la soustraction de la planet a un champ pour la déplacer
/// </summary>
public class PlantUnplant : MonoBehaviour
{
    [SerializeField] PlantMain _main;

    /// <summary>
    /// applique les actions nécessaire au détachement de la plante du champ
    /// </summary>
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
