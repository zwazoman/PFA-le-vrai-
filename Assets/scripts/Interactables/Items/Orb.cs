using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes llors de la r�colte. H�ritage 
/// </summary>
public class Orb : Item
{
    [field : SerializeField]
    public int OrbValue { get; private set; }
}
