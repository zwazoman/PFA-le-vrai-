using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    bool _sowable = true;
    bool _isEmpty = true;
    [SerializeField] GameObject _plant;

    public void Plow()
    {
        _sowable = !_sowable;
        // changer le material en champ bèché
    }
    public void Sow()
    {
        if (_sowable && _isEmpty)
        {
            Debug.Log("Absorber");
            Instantiate(_plant, transform.position, Quaternion.identity);
            _isEmpty = false;
        }        
    }
}