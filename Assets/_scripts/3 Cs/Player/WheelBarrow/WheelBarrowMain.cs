using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// main regroupant les références du fonctionnement de la brouette
/// </summary>
public class WheelBarrowMain : MonoBehaviour
{
    public WheelBarrowHandles WB { get; set; }

    [field: SerializeField]
    public WheelBarrowInputManager InputManager { get; private set; }

    [field : SerializeField]
    public WheelBarrowMovement Movement { get; private set; }

    [field : SerializeField]
    public PlayerInput Input { get; private set; }

    [field : SerializeField]
    public WheelBarrowStorage Storage { get; private set; }

    public bool isDrivingTheBrouette = false;

    private void Start()
    {
        InputManager.OnDrop += UnEquip;
    }

    /// <summary>
    /// change l'action map pour celle de la brouette
    /// </summary>
    public void Equip()
    {
        isDrivingTheBrouette = true;
        Input.SwitchCurrentActionMap("WheelBarrow");
        PlayerMain.Instance.Movement.enabled = false;
        PlayerMain.Instance.GrabBox.enabled = false;
    }

    /// <summary>
    /// re-change l'action map et la déséquippe
    /// </summary>
    public void UnEquip()
    {
        isDrivingTheBrouette = false;
        Input.SwitchCurrentActionMap("Player");
        WB.UnEquip();
        PlayerMain.Instance.Movement.enabled = true;
        PlayerMain.Instance.GrabBox.enabled = true;
    }
}
