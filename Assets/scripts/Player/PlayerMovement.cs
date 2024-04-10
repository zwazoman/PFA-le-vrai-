using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager _inputManager;
    Rigidbody rb;
    //vitesse de marche du joueur
    [SerializeField] float _playerWalkSpeed;
    //vitesse de course du joueur
    [SerializeField] float _playerRunSpeed;
    //vitesse a laquelle le joueur tourne
    [SerializeField] float _turnSpeed;
    //acceleration du joueur lors de ses déplacements
    [SerializeField] float _acceleration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnSprintStart += StartRunning; // début course
        _inputManager.OnSprintEnd -= StopRunning; // fin course
    }

    private void Update()
    {
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 45)) * new Vector3(_inputManager.moveInput.x, rb.velocity.y, _inputManager.moveInput.y);
        Move(direction,_playerWalkSpeed,_acceleration);
        if(rb.velocity.magnitude > 1f)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg); // rotaton jolie
        }
    }

    /// <summary>
    /// gère les mouvements du joueur en utilisant la physique des rigidbodies
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="maxSpeed"></param>
    /// <param name="acceleration"></param>
    public void Move(Vector3 direction, float maxSpeed, float acceleration)
    {
        float currentSpeed = rb.velocity.magnitude;
        float AddSpeed = Mathf.Clamp(maxSpeed - currentSpeed, 0, acceleration * Time.deltaTime);
        rb.velocity += (AddSpeed * direction);
    }

    /// <summary>
    /// gère le début de la course du joueur a la réception de l'event "onSprintStart"
    /// </summary>
    private void StartRunning()
    {

    }

    /// <summary>
    /// gère la fin de la course du joueur a la réception de l'event "onSprintEnd"
    /// </summary>
    private void StopRunning()
    {

    }
}
