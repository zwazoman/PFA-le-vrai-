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
    [SerializeField] PlantMain _plantMain;

    public bool CanWater { get; set; }


    private void Awake()
    {
        corruptionValue = 0;


        SetCorruptionValue(baseCorruption);
        Debug.Log(corruptionValue);

    }

    private void Start()
    {
        TimeManager.Instance.OnDay+= UpdateCorruption;
    }


    public void UpdateCorruption()
    {
        //si on l'a arrosé ce jour-ci , elle pousse pendant la nuit.Sinon, elle se corromp.
        if(CanWater)
        SetCorruptionValue(corruptionValue + CorruptionRateWhenNotWatered); 
        else SetCorruptionValue(corruptionValue - NaturalGrowRateWhenWatered);

        CanWater = true;
                                              
    }

    public void ReduceCorruption(float reduce) //reduit la corruption acec l'arrosoire 
    {
        SetCorruptionValue( corruptionValue - reduce);
        if (corruptionValue < 0.2f) //si le seuil de corruption est en dessous de 0.20 alors on peut ramassé la plante
        {
            _plantMain.Harvest.isHarvesteable = true;

        }
        if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
            {
                Destroy(_corruptionZone);
                CorruptionRateWhenNotWatered /= 2;
            }
    }


    //Gere la corruption (Setter)
    public void SetCorruptionValue(float newValue) 
    {
        newValue = Mathf.Clamp01(newValue);
        corruptionValue = newValue;

        //Gestion du nuage de corruption
        if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null)
        {
            _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position , _corruptionZonePrefab.transform.rotation, gameObject.transform);
            _plantMain.Harvest.isHarvesteable = false;

        }

        else if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
        {
            Destroy(_corruptionZone);
        }
        Debug.Log(corruptionValue);

        //mise à jour des visuels
        _plantMain.Visuals.UpdateVisuals(1f-newValue);
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