using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Tool
{
    /// <summary>
    /// gère les différentes possibilités lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantHarvest>(out PlantHarvest harvest)) // si c'ets une plante
            {
                harvest.Harvest(); // récolte la plante
            }
        }
    }
}
