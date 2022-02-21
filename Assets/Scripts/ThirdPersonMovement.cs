using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject good, devil;
    float turnSmoothVelocity;
    public bool isMoving;
    Vector3 moveVector;
    public bool isGood = true;
    void Update()
    {
        moveVector = Vector3.zero;
        if (controller.isGrounded == false)
        {
            moveVector += Physics.gravity;
        }
        controller.Move(moveVector * Time.deltaTime);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            isMoving = true;
            anim.SetBool("Walking", true);
            Invoke("Run", 0.3f);
            Debug.Log(anim.GetBool("Walking"));


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
        else
        {
            isMoving = false;
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("TimeTravel");
            if (isGood)
            {
                Invoke("Good", 1);
            }
            else
            {
                Invoke("Devil", 1);
            }
        }
    }
    private void Run()
    {
        speed = 6f;
        anim.SetBool("Running", true);
    }
    private void Good()
    {
        devil.SetActive(true);
        good.SetActive(false);
        isGood = false;
    }
    private void Devil()
    {
        devil.SetActive(false);
        good.SetActive(true);
        isGood = true;
    }
}
