using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    [field : SerializeField]
    public GameObject Plant { get; private set; }
}
