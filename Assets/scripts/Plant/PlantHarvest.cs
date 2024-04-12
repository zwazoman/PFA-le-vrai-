using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHarvest : MonoBehaviour
{
    public bool isHarvesteable { get; set; }
    [SerializeField] PlantMain _main;

    private void Awake()
    {
        isHarvesteable = false;
    }
    public void Harvest()
    {
        print("try harvest");
        if (!isHarvesteable) return;
        print("harvest");
        Instantiate(_main.orb, transform.position, Quaternion.identity);
        _main.PlantField.IsEmpty = true;
        _main.PlantField.Plow();
        Destroy(gameObject);
    }
}