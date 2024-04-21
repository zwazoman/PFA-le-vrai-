using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    [SerializeField] ItemJump _itemJump;

    [field : SerializeField]
    public GameObject Plant { get; private set; }

    private void Start()
    {
        _itemJump.Jump();
    }
}
