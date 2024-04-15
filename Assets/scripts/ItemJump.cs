using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJump : MonoBehaviour
{
     public Rigidbody RB { get; set; }
    [SerializeField] float _jumpForce = 10;
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    public void Jump()
    {
        Vector3 direction = new Vector3(Random.Range(-0.2f, 0.2f), 0.5f, Random.Range(-0.2f, 0.2f));
        RB.AddForce(direction * _jumpForce, ForceMode.Impulse); // fait sauter l'objet lorsqu'il est instancié
    }
}
