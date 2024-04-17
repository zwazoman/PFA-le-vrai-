using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelBarrowMain : MonoBehaviour
{
    [field: SerializeField]
    public WheelBarrowInputManager InputManager { get; private set; }

    [field : SerializeField]
    public WheelBarrowMovement Movement { get; private set; }

    [field : SerializeField]
    public PlayerInput Input { get; private set; }

    private void Start()
    {
        InputManager.OnDrop += UnEquip;
    }
    public void Equip()
    {
        Input.SwitchCurrentActionMap("WheelBarrow");
    }

    public void UnEquip()
    {
        Input.SwitchCurrentActionMap("Player");
    }
}
