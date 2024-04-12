using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    bool _sowable;
    public bool IsEmpty {get;set;}
    private GameObject _plant;

    private void Awake()
    {
        IsEmpty = true;
        _sowable = true;
    }

    public void Plow()
    {
        _sowable = !_sowable;
        // changer le material en champ bèché
    }
    public void Sow(GameObject seed)
    {
        if (_sowable && IsEmpty)
        {
            _plant = seed.GetComponent<Seed>().Plant;
            GetComponent<FieldStorage>().enabled = false;
            GameObject plant = Instantiate(_plant, transform.position, Quaternion.identity);
            plant.GetComponent<PlantMain>().PlantField = this;
            IsEmpty = false;
        }
    }
}