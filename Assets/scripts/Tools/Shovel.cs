using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Shovel : Tool
{

    [SerializeField] float _plantJumpForce;
    public override void Use()
    {
        base.Use();
        foreach(var hitCollider  in hitColliders)
        {
            if(hitCollider.TryGetComponent<PlantMain>(out PlantMain plantMain)) // si c'est une plante
            {
                plantMain.Unplant.Unplant();
            }
        }
    }
}
