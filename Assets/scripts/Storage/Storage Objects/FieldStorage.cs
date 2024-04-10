using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStorage : Storage
{
    protected override bool CanAbsorb(Item item)
    {
        return false;
        //return item.GetType(Orb);
    }

    protected override void OnAbsorb()
    {
        // appeler le script pour pousser 
        Destroy(this);
    }
}
