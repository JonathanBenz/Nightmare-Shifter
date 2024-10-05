using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    private bool hasControl; 

    Animator animator;
    Rigidbody rb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        float movementInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed;

        if(movementInput > 0)
        {
            animator.SetBool("walkForward", true);
            animator.SetBool("walkBackward", false);
            animator.SetBool("idle", false);
        }
        else if(movementInput < 0)
        {
            animator.SetBool("walkForward", false);
            animator.SetBool("walkBackward", true);
            animator.SetBool("idle", false);
        }
        else if(movementInput < 0.1)
        {
            animator.SetBool("walkForward", false);
            animator.SetBool("walkBackward", false);
            animator.SetBool("idle", true);
        }
        transform.Rotate(0, rotationInput * Time.deltaTime, 0);
    }
}
