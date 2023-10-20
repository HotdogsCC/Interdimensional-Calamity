using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float moveSpeed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

    }

    private void PlayerInput()
    {
        var tempMoveSpeed = moveSpeed * Time.deltaTime;
        var keysHeld = 0;
        var up = false;
        var down = false;
        var left = false;
        var right = false;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            keysHeld++;
            down = true;
            //rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - tempMoveSpeed, rb.transform.position.z);
            rb.AddForce(new Vector2(0, moveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
            keysHeld++;
            rb.transform.position = new Vector3(rb.transform.position.x - tempMoveSpeed, rb.transform.position.y, rb.transform.position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
            keysHeld++;
            rb.transform.position = new Vector3(rb.transform.position.x + tempMoveSpeed, rb.transform.position.y, rb.transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            up = true;
            keysHeld++;
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + tempMoveSpeed, rb.transform.position.z);
        }


        switch (keysHeld)
        {
            case 4:
                animator.SetBool("movingDown", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                return;
            case 3:
                if (up == false)
                {
                    animator.SetBool("movingDown", true);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                if (down == false)
                {
                    animator.SetBool("movingUp", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                if (left == false)
                {
                    animator.SetBool("movingRight", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                }
                if (right == false)
                {
                    animator.SetBool("movingLeft", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingRight", false);
                }
                return;
            case 2:
                if(up && down)
                {
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                else if (up)
                {
                    animator.SetBool("movingUp", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                else if (down)
                {
                    animator.SetBool("movingDown", true);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                else if (left && right)
                {
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                return;
            case 1:
                if (up)
                {
                    animator.SetBool("movingUp", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                if (down)
                {
                    animator.SetBool("movingDown", true);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                    animator.SetBool("movingRight", false);
                }
                if (left)
                {
                    animator.SetBool("movingLeft", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingRight", false);
                }
                if (right)
                {
                    animator.SetBool("movingRight", true);
                    animator.SetBool("movingDown", false);
                    animator.SetBool("movingUp", false);
                    animator.SetBool("movingLeft", false);
                }
                return;
            case 0:
                animator.SetBool("movingDown", false);
                animator.SetBool("movingUp", false);
                animator.SetBool("movingLeft", false);
                animator.SetBool("movingRight", false);
                return;
        }
        
    }
}