using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    //public Animator animator;

    private float moveSpeed = 5f;
    private Vector2 movement;
    

    

    


    void Update()
    {


        {
            /*
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (rb.velocity.y > 0)
            {
                animator.SetBool("runUp", true);
                animator.SetBool("runDown", false);
                animator.SetBool("runRight", false);
                animator.SetBool("runLeft", false);
                animator.SetBool("idle", false);

            }
            else if (rb.velocity.y < 0)
            {
                animator.SetBool("runDown", true);
                animator.SetBool("runUp", false);
                animator.SetBool("runRight", false);
                animator.SetBool("runLeft", false);
                animator.SetBool("idle", false);
            }
            else if (rb.velocity.x > 0)
            {
                animator.SetBool("runRight", true);
                animator.SetBool("runLeft", false);
                animator.SetBool("runDown", false);
                animator.SetBool("runUp", false);
                animator.SetBool("idle", false);
            }
            else if (rb.velocity.x < 0)
            {
                animator.SetBool("runRight", false);
                animator.SetBool("runLeft", true);
                animator.SetBool("runDown", false);
                animator.SetBool("runUp", false);
                animator.SetBool("idle", false);
            }
            else
            {
                animator.SetBool("idle", true);
            }*/
        }//rough animations

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        Vector2 direction = movement.normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

    }
}
