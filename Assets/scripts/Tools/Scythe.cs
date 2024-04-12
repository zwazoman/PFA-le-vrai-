using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Tool
{
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantHarvest>(out PlantHarvest harvest))
            {
                harvest.Harvest();
            }
        }
    }
}
