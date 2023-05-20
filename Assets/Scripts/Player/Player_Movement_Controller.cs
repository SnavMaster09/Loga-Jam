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

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Flip();
        VelocityStates();
        
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
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void VelocityStates()
    {


        if (movement.x > 0 && movement.y == 0)
            state = State.runSide;
        else if (movement.x < 0 && movement.y == 0)
            state = State.runSide;
        else if (movement.y > 0 && movement.x > 0)
            state = State.runBackSide;
        else if (movement.y > 0 && movement.x < 0)
            state = State.runBackSide;
        else if (movement.y < 0 && movement.x > 0)
            state = State.runFrontSide;
        else if (movement.y < 0 && movement.x < 0)
            state = State.runFrontSide;
        else if (movement.y < 0 && movement.x == 0)
            state = State.runFront;
        else if (movement.y > 0 && movement.x == 0)
            state = State.runBack;
        else state = State.idle;

        anim.SetInteger("state", (int)state);
    }
}
