using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Envoie un event au champ
/// </summary>
public class FieldStorage : Storage
{
    [SerializeField] Field _field;
    protected override bool CanAbsorb(Item item)
    {
        return item.GetType() == typeof(Seed);
    }

    protected override void OnAbsorb(GameObject seed)
    {
        _field.Sow(seed);
    }
}
