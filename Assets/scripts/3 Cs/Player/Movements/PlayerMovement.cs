using CustomInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : DynamicObject
{
    PlayerInputManager _inputManager;

    [HorizontalLine("Player Stats",1,FixedColor.DarkGray)]
    //vitesse de marche du joueur
    [SerializeField] float _playerMoveSpeed;
    //vitesse de course du joueur
    [SerializeField] float _playerRunFactor;
    //acceleration du joueur lors de ses déplacements
    [SerializeField] float _acceleration, airAcceleration;


    private void Awake()
    {
        initPhysics();
    }

    private void LateUpdate()
    {
        UpdatePhysics();
    }

    private void Start()
    {
        _inputManager = PlayerMain.Instance.InputManager;
        _inputManager.OnSprintStart += StartRunning; // début course
        _inputManager.OnSprintEnd += StopRunning; // fin course
    }

    private void Update()
    {
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 45)) * new Vector3(_inputManager.moveInput.x, 0, _inputManager.moveInput.y);
        Move(direction.normalized,_playerMoveSpeed,isGrounded? _acceleration: airAcceleration );
        if(Velocity.magnitude > 1f)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Atan2(Velocity.x, Velocity.z) * Mathf.Rad2Deg); // rotaton jolie
        }
        //print(_playerMoveSpeed);
    }

    /// <summary>
    /// gère le début de la course du joueur a la réception de l'event "onSprintStart"
    /// </summary>
    private void StartRunning()
    {
        _playerMoveSpeed *= _playerRunFactor; // multiplie la vitesse par le "runFactor"
    }

    /// <summary>
    /// gère la fin de la course du joueur a la réception de l'event "onSprintEnd"
    /// </summary>
    private void StopRunning()
    {
        _playerMoveSpeed /= _playerRunFactor; // rétablie la vitesse
    }


}
