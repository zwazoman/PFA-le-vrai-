using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    [field : SerializeField]
    protected float ToolLength { get; private set; }
    [field : SerializeField]
    protected float ToolRange { get; private set; }

    protected Collider[] hitColliders { get; private set; }

    public virtual void Use() 
    {
        hitColliders = Physics.OverlapSphere(transform.position + transform.forward * ToolLength, ToolRange);
    }
}
