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
    public PlantVisuals Visuals { get; private set; }

    [field: SerializeField]
    public Bulle_Plantes bulleTrigger { get; private set; }


    public bool CanWater { get; set; } = true;

    public void Unplant()
    {
        PlantField.IsEmpty = true;
        PlantField.Plow();
        Destroy(gameObject);
    }
}
