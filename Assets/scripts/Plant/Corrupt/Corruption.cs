using UnityEngine;
    /// <summary>
    /// Gere la corruption de la plante
    /// </summary>
public class Corruption : MonoBehaviour
{
    public float corruptionValue {get; set;}
    GameObject _corruptionZone;
    [SerializeField] GameObject _corruptionZonePrefab;
    [SerializeField] float _corruptionSpawnValue;
    [SerializeField] float _addCorruption;


    private void Awake()
    {
        corruptionValue = 0;
    }

    public void CorruptionStart()
    {
        if (TimeManager.Instance.Hour % 2 == 0)
        {
            SetCorruptionValue(corruptionValue + _addCorruption); //Augmente la corruption toute les 2h

            //Gestion du nuages de corruption
            if (corruptionValue >= _corruptionSpawnValue && _corruptionZone == null) 
            {
                _corruptionZone = Instantiate(_corruptionZonePrefab, transform.position+Vector3.up, _corruptionZonePrefab.transform.rotation); ;
            }
            else if (corruptionValue <= _corruptionSpawnValue && _corruptionZone != null)
            {
                Destroy(_corruptionZone);
            }
            Debug.Log(corruptionValue);
        }       
    }

    //Gere la corruption (Setter)
    public void SetCorruptionValue(float newValue) 
    {
        newValue = Mathf.Clamp01(newValue);
        corruptionValue = newValue;
    }
}
