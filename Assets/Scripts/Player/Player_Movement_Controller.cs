using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    private float moveSpeed = 5f;
    private Vector2 movement;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private bool isFacingRight = true;
    private bool isAttacking = false;

    private int lastDir = 1;
    //1=front 2=back 3=left 4=right 5=frontleft 6=frontright 7=backleft 8=backright

    public enum State {idle,runSide,runBack,runFront,runBackSide,runFrontSide,attack};
    public State state;

    public GameObject angle;

    private void Start()
    {
        //angle.SetActive(false);
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(state);

        Flip();
        VelocityStates();
        AttackStates();

        if (lastDir == 1)
            angle.transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (lastDir == 2)
            angle.transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (lastDir == 3)
            angle.transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (lastDir == 4)
            angle.transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (lastDir == 5)
            angle.transform.rotation = Quaternion.Euler(0, 0, 225);
        else if (lastDir == 6)
            angle.transform.rotation = Quaternion.Euler(0, 0, 135);
        else if (lastDir == 7)
            angle.transform.rotation = Quaternion.Euler(0, 0, 315);
        else if (lastDir == 8)
            angle.transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    private void FixedUpdate()
    {
        Vector2 direction = movement.normalized;
        rb.velocity = new Vector2(direction.x * Player_Manager.speed, direction.y * Player_Manager.speed);

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

    private void AttackStates()
    {
        if (Input.GetMouseButtonDown(0) && isAttacking == false)
        {
            StartCoroutine(Attack());
        }
    }

    private void VelocityStates()
    {


        if (movement.x > 0 && movement.y == 0 && isAttacking == false)
        {
            state = State.runSide;
            lastDir = 4;
        }
        else if (movement.x < 0 && movement.y == 0 && isAttacking == false)
        {
            state = State.runSide;
            lastDir = 3;
        }
        else if (movement.y > 0 && movement.x > 0 && isAttacking == false)
        {
            state = State.runBackSide;
            lastDir = 6;
        }
        else if (movement.y > 0 && movement.x < 0 && isAttacking == false)
        {
            state = State.runBackSide;
            lastDir = 5;
        }
        else if (movement.y < 0 && movement.x > 0 && isAttacking == false)
        {
            state = State.runFrontSide;
            lastDir = 8;
        }
        else if (movement.y < 0 && movement.x < 0 && isAttacking == false)
        {
            state = State.runFrontSide;
            lastDir = 7;
        }
        else if (movement.y < 0 && movement.x == 0 && isAttacking == false)
        {
            state = State.runFront;
            lastDir = 1;
        }
        else if (movement.y > 0 && movement.x == 0 && isAttacking == false)
        {
            state = State.runBack;
            lastDir = 2;
        }
        else if (isAttacking == false)
            state = State.idle;

        

        
        anim.SetInteger("state", (int)state);
        angle.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    //1=front 2=back 3=left 4=right 5=frontleft 6=frontright 7=backleft 8=backright

    private IEnumerator Attack()
    {
        isAttacking = true;
        state = State.attack;
        
        anim.SetInteger("state", (int)state);

        

        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        yield return new WaitForSeconds(0.1f);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Health>().takeDamage(Player_Manager.swordDamage);
        }

        yield return new WaitForSeconds(0.25f);
        isAttacking = false;
        
    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;  

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
