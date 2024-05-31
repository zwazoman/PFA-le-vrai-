using UnityEngine;

/// <summary>
/// g�re la r�colte de la plante lorsqu'elle re�oit un coup de faux
/// </summary>
public class PlantHarvest : MonoBehaviour
{
    /// <summary>
     /// la plante est r�coltable quand sa corruption atteint 0
     /// </summary>
    public bool isHarvesteable => _main.Corruption.corruptionValue <= 0; 

    [SerializeField] PlantMain _main;

    [Header("SFX")]
    [SerializeField] AudioClip[] _cutSounds;
    [SerializeField] float _cutVolume = 1f;

    [SerializeField] AudioClip[] _juiceSounds;
    [SerializeField] float _juiceVolume = 1f;


    /// <summary>
    ///  fait appara�tre une orbe et d�truit la plante si elle est recoltable
    /// </summary>
    public void Harvest()
    {
        if (!isHarvesteable) return; // v�rifie si la plante est r�coltable

        SFXManager.Instance.PlaySFXClip(_cutSounds, transform.position, _cutVolume);
        SFXManager.Instance.PlaySFXClip(_juiceSounds, transform.position, _juiceVolume);
        QuestManager.Instance.TryProgressQuest("SowSeed", 1);
        Instantiate(_main.orb, _main.Visuals.sparkleVFX.transform.position, Quaternion.identity).gameObject.transform.localScale = _main.orb.transform.localScale; //fait spawn un orbe

        _main.PlantField.IsEmpty = true; // annonce au champ qu'il est vide
        _main.PlantField.Plow(); // retourne le champ
        Destroy(gameObject); // d�truit la plante
    }
}