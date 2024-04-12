using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Tool
{
    public override void Use()
    {
        base.Use();
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<Field>(out Field field))
            {
                if (field.Sowable) return;
                field.Plow();
            }
            /*
             * if (hitCollider.gameObject.TryGetComponent<Breakable>(out Breakable breakable))
            {
                breakable.Break()
            }
            */
        }
    }
}