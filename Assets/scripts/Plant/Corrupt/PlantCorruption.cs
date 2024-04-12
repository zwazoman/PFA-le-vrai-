using UnityEngine;
    /// <summary>
    /// Gere la corruption de la plante
    /// </summary>
public class PlantCorruption : MonoBehaviour
{
    public float corruptionValue {get; set;}
    GameObject _corruptionZone;
    [SerializeField] GameObject _corruptionZonePrefab;
    [SerializeField] float _corruptionSpawnValue;
    [SerializeField] float _addCorruption;
    [SerializeField] PlantMain _plantMain;


    private void Awake()
    {
        corruptionValue = 0;
    }

    private void Start()
    {
        TimeManager.Instance.OnHour += CorruptionStart;
    }

    public void CorruptionStart()
    {
        if (TimeManager.Instance.Hour % 2 == 0)
        {
            SetCorruptionValue(corruptionValue + _addCorruption); //Augmente la corruption toute les 2h

            //Gestion du nuages de corruption
            if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null) 
            {
                _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position+Vector3.up, _corruptionZonePrefab.transform.rotation);
                _plantMain.Harvest.isHarvesteable = false;
            }
            else if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
            {
                Destroy(_corruptionZone);
            }
            Debug.Log(corruptionValue);
        }       
    }

    public void ReduceCorruption(float reduce) //reduit la corruption acec l'arrosoire 
    {
        corruptionValue -= reduce;
        if (corruptionValue < 0.2f) //si le seuil de corruption est en dessous de 0.20 alors on peut ramassé la plante
        {
            _plantMain.Harvest.isHarvesteable = true;
        }
    }

    //Gere la corruption (Setter)
    public void SetCorruptionValue(float newValue) 
    {
        newValue = Mathf.Clamp01(newValue);
        corruptionValue = newValue;
    }
}
