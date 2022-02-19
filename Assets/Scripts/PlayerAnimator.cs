using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Walk");
        }
    }
}
