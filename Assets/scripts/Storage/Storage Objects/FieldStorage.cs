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
        return item.GetType() == typeof(Seed);
    }

    protected override void OnAbsorb(GameObject seed)
    {
        Field.Sow(seed);
    }
}
