using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gère la récolte de la plante lorsqu'elle reçoit un coup de faux
/// </summary>
public class PlantHarvest : MonoBehaviour
{
    public bool isHarvesteable { get; set; }
    [SerializeField] PlantMain _main;

    private void Awake()
    {
        isHarvesteable = false;
    }

    /// <summary>
    ///  fait apparaître une orbe et détruit la plante 
    /// </summary>
    public void Harvest()
    {
        print("try harvest");
        if (!isHarvesteable) return; // vérifie si la plante est récoltable
        print("harvest");
        Instantiate(_main.orb, transform.position, Quaternion.identity);
        _main.PlantField.IsEmpty = true; // annonce au champ qu'il est vide
        _main.PlantField.Plow(); // retourne le champ
        Destroy(gameObject); // détruit la plante
    }
}