using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// orb lach�e par les boutures d'�mes lors de la r�colte. H�ritage 
/// </summary>
public class Orb : Item
{
    Rigidbody _rb;
    [SerializeField] float _jumpForce;

    [field : SerializeField]
    public int OrbValue { get; private set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Vector3 direction = new Vector3(Random.Range(-0.2f,0.2f),0.5f, Random.Range(-0.2f, 0.2f));
        _rb.AddForce(direction * _jumpForce, ForceMode.Impulse); // fais sauter l'orbe lors de la r�colte
    }
}
