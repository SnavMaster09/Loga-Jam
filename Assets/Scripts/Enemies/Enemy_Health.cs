using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    private int maxHealth = 20;
    private  int health = 20;

    public Spider_Controller spiderControllerScript;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public  void takeDamage(int damage)
    {
        spiderControllerScript.canDealDamage = false;
        spiderControllerScript.switchColor();
        health = health - damage;
        if (health <= 0)
        {
            spiderControllerScript.state = Spider_Controller.State.die;
            StartCoroutine(Die());
        }
         
    }

    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
   

}
