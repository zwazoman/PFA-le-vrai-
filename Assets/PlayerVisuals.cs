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

        if (p.InputManager.moveInput == Vector2.zero) { footstepVFX.Stop();print("ta �te la mere"); } else footstepVFX.Play();
    }

    IEnumerator BreakIdle()
    {
        animator.SetBool("IdleBreaker",true); //idle breaker
        yield return null;
        animator.SetBool("IdleBreaker", false); //idle breaker

    }

    public void GrabItem()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0,0.95f,0.05f,(float a)=> animator.SetLayerWeight(1, a),Nathan.SmoothStep01));
    }

    public void releaseItem()
    {
        StartCoroutine(Nathan.InterpolateOverTime(0.95f, 0, 0.05f, (float a) => animator.SetLayerWeight(1, a), Nathan.SmoothStep01));

    }


}
