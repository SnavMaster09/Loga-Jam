using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyPlant_Controller : MonoBehaviour
{
    public bool isAttacking;

    private float attackTimer = 2;
    private float timer;

    private int damage = 25;

    public Animator anim;
    public Player_Manager playerManagerScript;
    public CircleCollider2D attackColl;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= attackTimer)
        {
            anim.SetBool("isAttacking", true);
            StartCoroutine(activeAttack());
            timer = 0;
        }
        else
        {
            timer = timer + Time.deltaTime;
            anim.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAttacking == true && collision.gameObject.tag == "Player")
        {
            playerManagerScript.takeDamage(damage);
            isAttacking = false;
        }
    }

    private IEnumerator activeAttack()
    {
        isAttacking = true;
        //attackColl.enabled = true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        //attackColl.enabled = false;
    }

   

}
