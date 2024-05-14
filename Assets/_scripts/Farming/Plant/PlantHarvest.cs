using UnityEngine;

/// <summary>
/// gère la récolte de la plante lorsqu'elle reçoit un coup de faux
/// </summary>
public class PlantHarvest : MonoBehaviour
{
    /// <summary>
     /// la plante est récoltable quand sa corruption atteint 0
     /// </summary>
    public bool isHarvesteable => _main.Corruption.corruptionValue <= 0; 

    [SerializeField] PlantMain _main;


    /// <summary>
    ///  fait apparaître une orbe et détruit la plante si elle est recoltable
    /// </summary>
    public void Harvest()
    {
        if (!isHarvesteable) return; // vérifie si la plante est récoltable

        Instantiate(_main.orb, _main.Visuals.sparkleVFX.transform.position, Quaternion.identity).gameObject.transform.localScale = _main.orb.transform.localScale; //fait spawn un orbe

        _main.PlantField.IsEmpty = true; // annonce au champ qu'il est vide
        _main.PlantField.Plow(); // retourne le champ
        Destroy(gameObject); // détruit la plante
    }
}