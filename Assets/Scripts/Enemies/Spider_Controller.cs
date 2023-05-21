using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Spider_Controller : MonoBehaviour
{

    public Spider_Shooter shooterScript;
    public Enemy_Health enemyHealthScript;

    private bool isFacingRight = true;

    public float speed = 3f;
    public int biteDamage = 10;

    public float step;
    private Transform target;
    public Animator anim;
    public SpriteRenderer spr;
    private bool canFollow = true;

    public bool canDealDamage = true;

    public enum State {chase,flee,idle,die};
    public State state;

    

    public BoxCollider2D coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" ) 
        {
            if (step < 0)
            {
                speed = speed * -1;
            }
            target = collision.transform;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (canDealDamage == true)
            {
                FindAnyObjectByType<Player_Manager>().takeDamage(biteDamage);
            }
            if (speed > 0)
            {
                speed = -speed;
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && target.transform.position.x - transform.position.x < 0f || !isFacingRight && target.transform.position.x - transform.position.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    private void Update()
    {

        SpiderChaser();

        if (state == State.idle)
            canDealDamage = true;

        anim.SetInteger("state", (int)state);
        Flip();


    }

    private void SpiderChaser()
    {
        if (target != null)
        {
            state = State.chase;
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        else if (target == null)
        {
            state = State.idle;
        }

        if (state == State.chase && speed < 0)
        {
            state = State.flee;
        }
    }

    public void switchColor()
    {
        StartCoroutine(colorS());
    }

    private IEnumerator colorS()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.75f);
        spr.color = Color.white;
    }

}
