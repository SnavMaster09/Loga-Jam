using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Spider_Controller : MonoBehaviour
{

    public Spider_Shooter shooterScript;

    public float speed = 3f;
    public int biteDamage = 10;

    public float step;
    private Transform target;
    private bool canFollow = true;

    public enum State {chase,flee,idle};
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

        if(collision.gameObject.tag == "Player")
        {
            FindAnyObjectByType<Player_Manager>().takeDamage(biteDamage);
            if (speed > 0)
            {
                speed = -speed;
            }
        }
        
        
        
    }



    private void Update()
    {

        SpiderChaser();


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

}
