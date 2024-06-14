using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_ToolButton : MonoBehaviour
{
    [SerializeField] GameObject bouton;

    [SerializeField] int index = 0;
    [SerializeField] AnimationCurve curve;
    bool gamepadActive;
    //[SerializeField] GameObject _toolButtons;
    [SerializeField] private PlayerInput _input;

    private void Awake()
    {
        if (Gamepad.all.Count > 0)
        {
            gamepadActive = true;
        }
    }
    public void activate()
    {

        StopAllCoroutines();
        if (gameObject.activeSelf && this.enabled) { StartCoroutine(Nathan.InterpolateOverTime(0, 1f, .4f, (float a) => bouton.transform.localScale = Vector3.one * curve.Evaluate(a))); }
    }

    private void Start()
    {
        switch (index)
        {
            case 0:
                PlayerMain.Instance.InputManager.OnHoe += activate;
                break;
            case 1:
                PlayerMain.Instance.InputManager.OnWateringCan += activate;
                break; 
            case 2:
                PlayerMain.Instance.InputManager.OnScythe += activate;
                break;
            case 3:
                PlayerMain.Instance.InputManager.OnInteract += activate;
                break;
        }

        
        
    }

    private void Update()
    {
        /*if (_input.currentControlScheme == "Gamepad")
        {
            _toolButtons.SetActive(true); 
        }
        else
        {
            _toolButtons.SetActive(false);
        }*/
    }
}
