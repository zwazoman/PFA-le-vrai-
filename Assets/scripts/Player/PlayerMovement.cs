using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DynamicObject
{
    PlayerInputManager _inputManager;
    //vitesse de marche du joueur
    [SerializeField] float _playerWalkSpeed;
    //vitesse de course du joueur
    [SerializeField] float _playerRunSpeed;
    //vitesse a laquelle le joueur tourne
    [SerializeField] float _turnSpeed;
    //acceleration du joueur lors de ses d�placements
    [SerializeField] float _acceleration;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        initPhysics();
    }

    private void LateUpdate()
    {
        UpdatePhysics();
    }

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnSprintStart += StartRunning; // d�but course
        _inputManager.OnSprintEnd -= StopRunning; // fin course
    }

    private void Update()
    {
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 45)) * new Vector3(_inputManager.moveInput.x, 0, _inputManager.moveInput.y);
        print("Move Direction : " + direction.ToString());
        Move(direction.normalized,_playerWalkSpeed,_acceleration);
        if(Velocity.magnitude > 1f)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Atan2(Velocity.x, Velocity.z) * Mathf.Rad2Deg); // rotaton jolie
        }
    }

    /// <summary>
    /// g�re les mouvements du joueur en utilisant la physique des rigidbodies
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="maxSpeed"></param>
    /// <param name="acceleration"></param>

    public void Move(Vector3 direction, float maxSpeed, float acceleration)
    {
        print($"Direction : {direction} , Max speed : {maxSpeed} , acceleration : {acceleration}");
        float currentSpeed = getFlatVelocity().magnitude;
        float AddSpeed = Mathf.Clamp(maxSpeed - currentSpeed, 0, acceleration * Time.deltaTime);
        AddImpulse(AddSpeed * direction);
    }

    /// <summary>
    /// g�re le d�but de la course du joueur a la r�ception de l'event "onSprintStart"
    /// </summary>
    private void StartRunning()
    {

    }

    /// <summary>
    /// g�re la fin de la course du joueur a la r�ception de l'event "onSprintEnd"
    /// </summary>
    private void StopRunning()
    {

    }
}
