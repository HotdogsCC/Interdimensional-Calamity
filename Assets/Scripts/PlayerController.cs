using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Moves the character
        rb.velocity = movement * Time.deltaTime * moveSpeed;
        
        AnimateTheCharacter();

        // Checks whether the sprint key is being held or nah
        if (playerInput.actions["Sprint"].IsPressed())
        {
            moveSpeed = 150;
        }
        else
        {
            moveSpeed = 100;
        }
    }

    private void AnimateTheCharacter()
    {
        switch (movement.x)
        {
            case 1f:
                animator.SetBool("movingDown", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", true);
                break;
            case -1f:
                animator.SetBool("movingDown", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingLeft", true);
                animator.SetBool("movingRight", false);
                break;
            case 0:
                if(movement.y == 0)
                {
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                break;
            default:
                if(movement.x > 0)
                {
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", true);
                }
                else
                {
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", true);
                    animator.SetBool("movingRight", false);
                }
                break;


        }
        switch (movement.y)
        {
            case 1f:
                animator.SetBool("movingDown", false);
                animator.SetBool("movingUp", true);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                break;
            case -1f:
                animator.SetBool("movingDown", true);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                break;
        }
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
        
    private void OnSprint(InputValue value)
    {

    }

    
}
