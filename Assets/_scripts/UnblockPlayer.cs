using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockPlayer : MonoBehaviour
{
    public void Unblock()
    {
        gameObject.transform.position = transform.position + Vector3.up*6;
    }
}
