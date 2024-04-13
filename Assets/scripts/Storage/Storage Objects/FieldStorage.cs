using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// g�re la r�cup�ration de graines dans le champ et indique au champ qu'il a re�u une graine
/// </summary>
public class FieldStorage : Storage
{
    [field : SerializeField]  
    public Field Field { get; set; }
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Seed) || item.GetType() == typeof(Plant);
    }

    protected override void OnAbsorb(GameObject item)
    {
        if (item.TryGetComponent<Seed>(out Seed seed))
        {
            Field.Sow(item);
            Destroy(item);
        }
        else
        {
            Field.RePlant(item);
        }
    }
}
