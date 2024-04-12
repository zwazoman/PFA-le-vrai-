using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMain : MonoBehaviour
{
    [field : SerializeField] 
    public GameObject orb { get; private set; }

    public Field PlantField { get; set; }

    [field: SerializeField]
    public PlantHarvest Harvest { get; private set; }

    /*[field : SerializeField]
    public PlantGrow Grow { get; private set; }*/
}
