using UnityEngine;
/// <summary>
/// Gere la corruption de la plante
/// </summary>
public class PlantCorruption : MonoBehaviour
{
    public float corruptionValue {get; private set; }
    GameObject _corruptionZone;
    [SerializeField] GameObject _corruptionZonePrefab;
    [SerializeField] float _corruptionSpawnValue;

    [SerializeField] float baseCorruption = 0.2f;

    [field:SerializeField] public float CorruptionRateWhenNotWatered { get; set;}
    [SerializeField] float NaturalGrowRateWhenWatered;
    [SerializeField] PlantMain _Main;


    //[Header("SFX")]
    //[SerializeField] AudioClip[] _plantReadySound;
    //[SerializeField] float _plantReadySoundVolume = 1f;

    

    private void Start()
    {
        _Main.bulleTrigger.spawnBubbleWhenPlayerIsNear = true;

        SetCorruptionValue(baseCorruption);
        TimeManager.Instance.OnMorning+= UpdateCorruption;
    }


    public void UpdateCorruption()
    {
        if (_Main.Harvest.isHarvesteable) return; //une fois que la plante a totalement poussé, il n'ya plus besoin de l'arroser et elle reste comme ça, à moins qu'un nuage de corruption n'apparaisse à coté

        //si on l'a arrosé ce jour-ci , elle pousse pendant la nuit.Sinon, elle se corromp.
        if (_Main.CanWater)
        {
            _Main.CanWater = true;
            SetCorruptionValue(corruptionValue + CorruptionRateWhenNotWatered);
            
        }
        else
        {
            _Main.CanWater = true;
            SetCorruptionValue(corruptionValue - NaturalGrowRateWhenWatered);
        }
        _Main.bulleTrigger.spawnBubbleWhenPlayerIsNear = true;

    }

    public void ReduceCorruption(float reduce) //reduit la corruption acec l'arrosoire 
    {
        SetCorruptionValue(corruptionValue - reduce);
        _Main.Visuals.PlayWateredAnimation();
        //if (_Main.Harvest.isHarvesteable) SFXManager.Instance.PlaySFXClip(_plantReadySound, transform.position, _plantReadySoundVolume);
    }


    //permet de changer la corruption (Setter)
    public void SetCorruptionValue(float newValue) 
    {
        newValue = Mathf.Clamp01(newValue);
        corruptionValue = newValue;

        //Gestion du nuage de corruption
        if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null)
        {
            _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position , _corruptionZonePrefab.transform.rotation, gameObject.transform); //on le fait spawn si la corruption est assez haute
        }
        else if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null) //on le detruit si la corruption est assez basse
        {
            Destroy(_corruptionZone);
        }

        //mise à jour des visuels
        _Main.Visuals.UpdateVisuals(1f-newValue);
    }


    private void OnDestroy()
    {
        TimeManager.Instance.OnDay -= UpdateCorruption;
    }

    public void FreezeCorruption()
    {
        TimeManager.Instance.OnDay -= UpdateCorruption;
        print("freeze corruption");
    }

    public void UnFreezeCorruption()
    {
        TimeManager.Instance.OnDay += UpdateCorruption;
        print("unfreeze corruption");
    }
}