using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] Animator animator;
    PlayerMovement mv;

    PlayerMain p => PlayerMain.Instance;

    [SerializeField]VisualEffect footstepVFX;
    private void Start()
    {
        footstepVFX.Stop();

        mv = p.Movement;
        PlayerInputManager i = p.InputManager;
        i.OnSprintStart+= ()=> animator.SetBool("running",true);
        i.OnSprintEnd+= ()=> animator.SetBool("running", false);


        Application.targetFrameRate = 30;

        InvokeRepeating("TryIdleBreaker", 2, 2);
    }

    public void startScytheAnimation()
    {
        animator.SetTrigger("Faux");
        
    }

    public void startHoeAnimation()
    {
        animator.SetTrigger("Houe");
    }

    public void startWateringAnimation()
    {
        animator.SetTrigger("Arrosoir");
    }

    void TryIdleBreaker()
    {
        if (p.InputManager.moveInput == Vector2.zero && Random.value < 0.05f) StartCoroutine(BreakIdle());
    }

    private void Update()
    {
        animator.SetBool("moving", p.InputManager.moveInput != Vector2.zero ); //walk

        if (p.InputManager.moveInput == Vector2.zero) footstepVFX.Stop(); else footstepVFX.Play();
    }

    IEnumerator BreakIdle()
    {
        animator.SetBool("IdleBreaker",true); //idle breaker
        yield return null;
        animator.SetBool("IdleBreaker", false); //idle breaker

    }

    
}
