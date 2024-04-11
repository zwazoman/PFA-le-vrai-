using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// orb lachée par les boutures d'âmes llors de la récolte. Héritage 
/// </summary>
public class Orb : Item
{
    [field : SerializeField]
    public int OrbValue { get; private set; }
}
