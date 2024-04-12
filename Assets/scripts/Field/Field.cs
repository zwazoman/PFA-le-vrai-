using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// gère le champ et la plante de graines
/// </summary>
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

    /// <summary>
    /// change le mesh du champ, le rend apte a la plantation lors d'un coup de bêche
    /// </summary>
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

    /// <summary>
    /// fait apparaitre une plante et détruit le stockage du champ si le champe st ^pte a la plantation.
    /// </summary>
    /// <param name="seed"></param>
    public void Sow(GameObject seed)
    {
        print("try Sow");
        if (Sowable && IsEmpty)
        {
            print("sow");
            _plant = seed.GetComponent<Seed>().Plant;
            Destroy(GetComponent<FieldStorage>());
            GameObject plant = Instantiate(_plant, transform.position, Quaternion.identity);
            plant.GetComponent<PlantMain>().PlantField = this;
            IsEmpty = false;
        }
    }
}