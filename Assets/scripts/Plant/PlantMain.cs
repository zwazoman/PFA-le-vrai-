using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMain : MonoBehaviour
{
    [field: SerializeField]
    public GameObject orb { get; private set; }

    public Field? PlantField { get; set; }

    [field: SerializeField]
    public PlantHarvest Harvest { get; private set; }

    [field : SerializeField]
    public PlantCorruption Corruption { get; private set; }

    [field: SerializeField]
    public PlantUnplant Unplant {get;private set;}

    [field : SerializeField]
    public ItemJump Jump { get; private set; }

    public bool CanWater { get; set; }

    private void Start()
    {
        TimeManager.Instance.OnDay += () => CanWater = true;
    }
    private void Update()
    {
        print(PlantField);
    }
}
