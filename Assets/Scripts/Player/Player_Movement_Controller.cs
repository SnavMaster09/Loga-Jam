using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    private float moveSpeed = 5f;
    private Vector2 movement;


    private bool isFacingRight = true;


    public enum State {idle,runSide,runBack,runFront,runBackSide,runFrontSide};
    public State state;

    


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

        Flip();
        VelocityStates();

        Debug.Log((int)state);


    }

    private void FixedUpdate()
    {
        Vector2 direction = movement.normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

    }

    private void Flip()
    {
        if(isFacingRight && movement.x < 0f || !isFacingRight && movement.x > 0f)
        {
            Debug.Log(1);
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void VelocityStates()
    {


        if (movement.x > 0)
            state = State.runSide;
        else if (movement.x < 0)
            state = State.runSide;
        else state = State.idle;

        anim.SetInteger("state", (int)state);
    }
}
