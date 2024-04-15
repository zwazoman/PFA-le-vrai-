using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Item
{
    [SerializeField] ItemJump _itemJump;

    [field : SerializeField]
    public int OrbValue { get; private set; }

    private void Start()
    {
        _itemJump.Jump();
    }
}
