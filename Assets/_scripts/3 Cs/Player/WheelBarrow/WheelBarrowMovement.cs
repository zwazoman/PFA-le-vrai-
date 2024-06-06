using UnityEngine;

/// <summary>
/// déplacements du joueur avec la brouette (semi-remorque)
/// </summary>
public class WheelBarrowMovement : DynamicObject
{
    WheelBarrowInputManager _input;

    [SerializeField] public float _playerMoveSpeed;
    [SerializeField]  float _acceleration;
    [SerializeField] float _turnSpeed;
    float _rotY;
    public float decelerationY;

    private void Start()
    {
        _input = PlayerMain.Instance.WheelBarrow.InputManager;
    }

    private void Update()
    {
        _rotY *= Mathf.Pow(.5f, Time.deltaTime* decelerationY);
        Move(transform.forward * _input.MoveInput, _playerMoveSpeed, _acceleration);
        Turn();
    }

    private void Turn()
    {
        _rotY += _turnSpeed * Time.deltaTime * _input.TurnInput;
        transform.Rotate(Vector3.up  * Time.deltaTime * _rotY);
    }


}
