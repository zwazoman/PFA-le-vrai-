using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Tool
{
    private int _waterStorage;
    public int _maxWaterStorage { get; set; }
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<PlantCorruption>(out PlantCorruption corruption))
            {
                _waterStorage -= 1;
                // spawn particules d'eau ?
                // _corruption.Purify();
            }
            if(hitCollider.gameObject.TryGetComponent<Well>(out Well well))
            {
                _waterStorage = _maxWaterStorage;
            }
        }
    }
}
