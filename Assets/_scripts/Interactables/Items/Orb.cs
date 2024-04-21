using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// orb lachée par les boutures d'âmes lors de la récolte. Héritage 
/// </summary>
public class Orb : Item
{
    [field : SerializeField]
    public int OrbValue { get; private set; }

    private void Start()
    {
        Jump();
    }
}
