using CustomInspector;
using UnityEngine;

public class PlayerMovement : DynamicObject
{
    PlayerInputManager _inputManager;
    public bool IsRunning { get; private set; }

    [HorizontalLine("Player Stats",1,FixedColor.DarkGray)]
    //vitesse actuelle du joueur
    public float _playerMoveSpeed;

    //vitesse de marche du joueur
    public float PlayerWalkSpeed;
    //vitesse de course du joueur
    public float _playerRunFactor;
    //acceleration du joueur lors de ses déplacements
    [SerializeField] float _acceleration, airAcceleration;

    [SerializeField] float RotationInverseSpeed = 120f;

    public void Unblock()
    {
        if (isGrounded) 
        {
            gameObject.transform.position = transform.position + Vector3.up * 6;
        }
        
    }

    private void OnDisable()
    {
        ResetVelocity();
    }

    private void Awake()
    {
        initPhysics();
        SnapToGround();
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
        PlayerWalkSpeed = PlayerMain.Instance.Stats.WalkSpeed;
        _playerRunFactor = PlayerMain.Instance.Stats.RunFactor;
    }

    private void Update()
    {
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 45)) * new Vector3(_inputManager.moveInput.x, 0, _inputManager.moveInput.y);
        Move(direction.normalized,_playerMoveSpeed,isGrounded? _acceleration: airAcceleration );
        if(direction.sqrMagnitude >0.1f)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up *( Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg+90f))   , Time.deltaTime* RotationInverseSpeed); // rotaton jolie
        }
    }

    /// <summary>
    /// gère le début de la course du joueur a la réception de l'event "onSprintStart"
    /// </summary>
    private void StartRunning()
    {
        IsRunning = true;
        _playerMoveSpeed = PlayerWalkSpeed * _playerRunFactor; // multiplie la vitesse par le "runFactor"
    }

    /// <summary>
    /// gère la fin de la course du joueur a la réception de l'event "onSprintEnd"
    /// </summary>
    private void StopRunning()
    {
        IsRunning = false;
        _playerMoveSpeed = PlayerWalkSpeed; // rétablie la vitesse
    }


}
