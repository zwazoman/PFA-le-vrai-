using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] Animator animator;
    PlayerMovement mv;

    private void Start()
    {
        mv = PlayerMain.Instance.Movement;
        PlayerMain.Instance.InputManager.OnSprintStart+= ()=> animator.SetTrigger("OnRun");
        PlayerMain.Instance.InputManager.OnSprintEnd+= ()=> animator.SetTrigger("OnStopRunning");
    }

    
}
