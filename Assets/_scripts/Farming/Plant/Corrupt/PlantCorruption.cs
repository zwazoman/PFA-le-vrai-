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

    [field:SerializeField] public float _addCorruption { get; set;}
    [SerializeField] PlantMain _plantMain;
    [SerializeField] Material _plantReady;
    [SerializeField] Material _plantNotReady;
    MeshRenderer MR;
    public bool CanWater { get; set; }


    private void Awake()
    {
        corruptionValue = 0;
        MR = GetComponent<MeshRenderer>();
        _plantReady = MR.sharedMaterial;
        MR.sharedMaterial = _plantReady;

        TimeManager.Instance.OnDay += UpdateCorruption;
        SetCorruptionValue(baseCorruption);
        Debug.Log(corruptionValue);
        MR.sharedMaterial = _plantNotReady;
    }



    public void UpdateCorruption()
    {       
            SetCorruptionValue(corruptionValue + _addCorruption); //Augmente la corruption tous les jours 
            CanWater = true;
                                              
    }

    public void ReduceCorruption(float reduce) //reduit la corruption acec l'arrosoire 
    {
        SetCorruptionValue( corruptionValue - reduce);
        if (corruptionValue < 0.2f) //si le seuil de corruption est en dessous de 0.20 alors on peut ramassé la plante
        {
            _plantMain.Harvest.isHarvesteable = true;
            MR.sharedMaterial = _plantReady;
        }
        if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
            {
                Destroy(_corruptionZone);
                _addCorruption /= 2;
            }
    }


    //Gere la corruption (Setter)
    public void SetCorruptionValue(float newValue) 
    {
        newValue = Mathf.Clamp01(newValue);
        corruptionValue = newValue;

        //Gestion du nuages de corruption
        if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null)
        {
            _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position + Vector3.up, _corruptionZonePrefab.transform.rotation, gameObject.transform);
            _plantMain.Harvest.isHarvesteable = false;
            MR.sharedMaterial = _plantNotReady;
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