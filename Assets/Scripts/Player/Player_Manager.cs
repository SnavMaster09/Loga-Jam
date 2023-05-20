using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{

    public static bool activeCombat;

    private int maxHealth = 100;
    public static int health;

    void Start()
    {
        activeCombat = false;
        health = maxHealth;

    }

    void Update()
    {
        Debug.Log(health);
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health < 0)
            Debug.Log("Dead");
    }
}
