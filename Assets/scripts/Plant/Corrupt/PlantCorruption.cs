using UnityEngine;
/// <summary>
/// Gere la corruption de la plante
/// </summary>
public class PlantCorruption : MonoBehaviour
{
    public float corruptionValue {get; set;}
    GameObject _corruptionZone;
    [SerializeField] GameObject _corruptionZonePrefab;
<<<<<<< Updated upstream:Assets/scripts/Plant/Corrupt/PlantCorruption.cs
    [SerializeField] float _corruptionSpawnValue;
=======
    [SerializeField] float _corruptionSpawnTreshold;

    [SerializeField] float baseCorruption = 0.2f;

>>>>>>> Stashed changes:Assets/_scripts/Farming/Plant/Corrupt/PlantCorruption.cs
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
    }

    private void Start()
    {
        TimeManager.Instance.OnDay += CorruptionStart;
        corruptionValue = Random.Range(0.20f, 0.8f);
        Debug.Log(corruptionValue);
        MR.sharedMaterial = _plantNotReady;
    }

    public void CorruptionStart()
    {       
            SetCorruptionValue(corruptionValue + _addCorruption); //Augmente la corruption tous les jours 
            CanWater = true;
            //Gestion du nuages de corruption
            if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null) 
            {
                _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position+Vector3.up, _corruptionZonePrefab.transform.rotation, gameObject.transform);                
                _plantMain.Harvest.isHarvesteable = false;
                MR.sharedMaterial = _plantNotReady;
            }

            else if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
            {
                Destroy(_corruptionZone);
            }
            Debug.Log(corruptionValue);                                        
    }

    public void ReduceCorruption(float reduce) //reduit la corruption acec l'arrosoire 
    {
        corruptionValue -= reduce;
        if (corruptionValue < 0.2f) //si le seuil de corruption est en dessous de 0.20 alors on peut ramassé la plante
        {
            _plantMain.Harvest.isHarvesteable = true;
            MR.sharedMaterial = _plantReady;
        }
        if (corruptionValue <= _corruptionSpawnTreshold && _corruptionZone != null)
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
<<<<<<< Updated upstream:Assets/scripts/Plant/Corrupt/PlantCorruption.cs
=======

        //Gestion du nuages de corruption
        if (corruptionValue >= _corruptionSpawnTreshold && _corruptionZone == null)
        {
            _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position + Vector3.up, _corruptionZonePrefab.transform.rotation, gameObject.transform);
            _plantMain.Harvest.isHarvesteable = false;
            MR.sharedMaterial = _plantNotReady;
        }

        else if (corruptionValue <= _corruptionSpawnTreshold && _corruptionZone != null)
        {
            Destroy(_corruptionZone);
        }
        Debug.Log(corruptionValue);

        //mise à jour des visuels
        _plantMain.Visuals.UpdateVisuals(1f-newValue);
>>>>>>> Stashed changes:Assets/_scripts/Farming/Plant/Corrupt/PlantCorruption.cs
    }

    private void OnDestroy()
    {
        TimeManager.Instance.OnDay -= CorruptionStart;
    }

    public void FreezeCorruption()
    {
        TimeManager.Instance.OnDay -= CorruptionStart;
        print("freeze corruption");
    }

    public void UnFreezeCorruption()
    {
        TimeManager.Instance.OnDay += CorruptionStart;
        print("unfreeze corruption");
    }
}