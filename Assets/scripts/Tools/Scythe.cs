using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Tool
{
    /// <summary>
    /// g�re les diff�rentes possibilit�s lors de l'utilisation
    /// </summary>
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.TryGetComponent<PlantHarvest>(out PlantHarvest harvest)) // si c'ets une plante
            {
                harvest.Harvest(); // r�colte la plante
            }
        }
    }
}
