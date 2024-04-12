using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public bool Sowable { get; set; }
    public bool IsEmpty {get;set;}
    private GameObject _plant;
    MeshRenderer MR;
    [SerializeField] Material _sowableMaterial;
    [SerializeField] Material _notSowableMaterial;

    private void Awake()
    {
        IsEmpty = true;
        Sowable = false;
        MR = GetComponent<MeshRenderer>();
        _notSowableMaterial = MR.sharedMaterial;
    }

    public void Plow()
    {
        if(!IsEmpty) return;
        print("Plow");
        Sowable = !Sowable;
        if (Sowable)
        {
            FieldStorage storage = gameObject.AddComponent<FieldStorage>();
            storage.Field = this;
        }
        else
        {
            Destroy(GetComponent<FieldStorage>());
        }
        MR.sharedMaterial = Sowable ? _sowableMaterial: _notSowableMaterial;
    }
    public void Sow(GameObject seed)
    {
        if (Sowable && IsEmpty)
        {
            _plant = seed.GetComponent<Seed>().Plant;
            Destroy(GetComponent<FieldStorage>());
            GameObject plant = Instantiate(_plant, transform.position, Quaternion.identity);
            plant.GetComponent<PlantMain>().PlantField = this;
            IsEmpty = false;
        }
    }
}