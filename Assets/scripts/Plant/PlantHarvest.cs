using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re la r�colte de la plante lorsqu'elle re�oit un coup de faux
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
    ///  fait appara�tre une orbe et d�truit la plante 
    /// </summary>
    public void Harvest()
    {
        print("try harvest");
        if (!isHarvesteable) return; // v�rifie si la plante est r�coltable
        print("harvest");
        Instantiate(_main.orb, transform.position, Quaternion.identity);
        _main.PlantField.IsEmpty = true; // annonce au champ qu'il est vide
        _main.PlantField.Plow(); // retourne le champ
        Destroy(gameObject); // d�truit la plante
    }
}