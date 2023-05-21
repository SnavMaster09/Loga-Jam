using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 20;
    public   int health = 20;
    public int coins;

    public int type;

    public GameObject toBeDestroyed;
    public SpriteRenderer spr;

    public Spider_Controller spiderControllerScript;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public  void takeDamage(int damage)
    {

        if(type == 1)
            spiderControllerScript.canDealDamage = false;
        switchColor();
        health = health - damage;
        if (health <= 0)
        {
            if(type == 1)
                spiderControllerScript.state = Spider_Controller.State.die;
            StartCoroutine(Die());
        }
         
    }

    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(0.5f);
        Player_Manager.coins += coins;
        Destroy(toBeDestroyed);
        
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
