using System.Collections;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] Animator animator;
    PlayerMovement mv;

    PlayerMain p => PlayerMain.Instance;

    private void Start()
    {
        
        mv = p.Movement;
        PlayerInputManager i = p.InputManager;
        i.OnSprintStart+= ()=> animator.SetBool("running",true);
        i.OnSprintEnd+= ()=> animator.SetBool("running", false);

        //InvokeRepeating("TryIdleBreaker", 2, 2);
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

    public void StartDrinkAnimation()
    {
        animator.SetTrigger("Potion");
    }

    void TryIdleBreaker()
    {
        if (p.InputManager.moveInput == Vector2.zero && Random.value < 0.05f) StartCoroutine(BreakIdle());
    }

    private void Update()
    {
        animator.SetBool("holdingwheelbarrow", p.WheelBarrow.isDrivingTheBrouette);

        if (!p.WheelBarrow.isDrivingTheBrouette)
        {
            animator.SetLayerWeight(2, 0);
            animator.SetBool("moving", p.InputManager.moveInput != Vector2.zero); //walk
        }
        else
        {
            animator.SetLayerWeight(2, 1);

            animator.SetBool("moving", p.WBInputManager.MoveInput != 0);
            animator.SetFloat("wheelbarrowInput", p.WBInputManager.MoveInput);
        }

        
    }

    private void OnDisable()
    {
         animator.SetBool("moving", false); 
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

    public void EquiBarrow() 
    { 

    }
    public void UnEquiBarrow() 
    { 
    
    }
}
