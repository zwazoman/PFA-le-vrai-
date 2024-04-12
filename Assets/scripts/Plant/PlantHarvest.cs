using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHarvest : MonoBehaviour
{
    public bool isHarvesteable { get; set; }
    [SerializeField] PlantMain _main;

    public void Harvest()
    {
        if (!isHarvesteable) return;
        Instantiate(_main.orb, transform.position, Quaternion.identity);
        _main.PlantField.IsEmpty = true;
        Destroy(gameObject);
    }
}