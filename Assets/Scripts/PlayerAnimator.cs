using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private ThirdPersonMovement movement;
    private AnimationClip clip;
    private void Start()
    {
        animator = GetComponent<Animator>();
        movement = FindObjectOfType<ThirdPersonMovement>();
    }
    private void Update()
    {       
        if (movement.isMoving == true)
        {
            animator.SetBool("Walking", true);
            Invoke("Run", 0.3f);
            Debug.Log(animator.GetBool("Walking"));
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("TimeTravel");
        }
        
    }
    private void Run()
    {
        animator.SetBool("Running", true);
    }
}
