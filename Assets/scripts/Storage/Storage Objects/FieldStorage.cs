using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStorage : Storage
{
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Orb);
    }

    protected override void OnAbsorb(GameObject item)
    {
        // faire pousser la plante dans le champs
        //d�truire l'orbe
        Destroy(this);
    }
}
