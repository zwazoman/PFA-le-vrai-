using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re le champ et la plante de graines
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
    /// change le mesh du champ, le rend apte a la plantation lors d'un coup de b�che
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
    /// fait apparaitre une plante et d�truit le stockage du champ si le champe st ^pte a la plantation.
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
            GameObject plant = Instantiate(_plant, transform.position + Vector3.up, Quaternion.identity);
            plant.GetComponent<PlantMain>().PlantField = this;
            IsEmpty = false;
        }
    }
    /// <summary>
    /// remet une plant retir�e d'un champs via la pelle dans ce champ
    /// </summary>
    /// <param name="plant"></param>
    public void RePlant(GameObject plant)
    {
        if (Sowable && IsEmpty)
        {
            Destroy(GetComponent<FieldStorage>()); // detruit le storage
            plant.transform.position = transform.position + Vector3.up;
            //plant.transform.rotation = Quaternion.identity; // place la plante
            Destroy(plant.GetComponent<Rigidbody>()); // retire le rigidbody
            Destroy(plant.GetComponent<Plant>()); // retire Plant de type item
            plant.GetComponent<PlantMain>().PlantField = this; // d�finit ce champ comme �tant le champ de la plante
            IsEmpty = false;
        }
    }
}