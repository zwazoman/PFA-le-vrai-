using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager _inputManager;
    Rigidbody rb;
    [SerializeField] float _playerWalkSpeed;
    [SerializeField] float _playerRunSpeed;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _acceleration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnSprintStart += StartRunning;
        _inputManager.OnSprintEnd -= StopRunning;
    }

    private void Update()
    {
        print(_inputManager.moveInput);
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 45)) * new Vector3(_inputManager.moveInput.x, rb.velocity.y, _inputManager.moveInput.y);
        Move(direction,_playerWalkSpeed,_acceleration);
        if(rb.velocity.magnitude > 0.5f)
        {
            print("suu");
            transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg);
        }
    }

    public void Move(Vector3 direction, float maxSpeed, float acceleration)
    {
        float currentSpeed = rb.velocity.magnitude;
        float AddSpeed = Mathf.Clamp(maxSpeed - currentSpeed, 0, acceleration * Time.deltaTime);
        rb.velocity += (AddSpeed * direction);
        print(AddSpeed * direction);
    }

    /*private void Move()
    {
        rb.velocity = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up*45)) * new Vector3(_inputManager.moveInput.x, rb.velocity.y , _inputManager.moveInput.y);
    }*/

    private void StartRunning()
    {

    }

    private void StopRunning()
    {

    }
}
