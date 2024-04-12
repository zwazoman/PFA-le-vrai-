using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Tool
{
    private int _waterStorage;

    [SerializeField] float waterToGive;
    [field : SerializeField]
    public int MaxWaterStorage { get; set; }

    private void Awake()
    {
        _waterStorage = MaxWaterStorage;
    }

    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantCorruption>(out PlantCorruption corruption))
            {
                if (_waterStorage <= 0)
                {
                    print("plus d'eau");
                    return;
                }
                _waterStorage -= 1;
                print("water");
                corruption.ReduceCorruption(waterToGive);
                // spawn particules d'eau ?
            }
            if(hitCollider.gameObject.TryGetComponent<Well>(out Well well))
            {
                print("replenish water");
                _waterStorage = MaxWaterStorage;
            }
        }

    }
}
