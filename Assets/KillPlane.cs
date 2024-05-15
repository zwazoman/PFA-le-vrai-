using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{ 
    public Vector3 spawnPoint;

    [SerializeField] float killHeight = -32;
    private void Awake()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -32)
        {
            transform.position = spawnPoint;
        }
    }
}
