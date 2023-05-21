using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Manager : MonoBehaviour
{

    public static bool activeCombat;

    public static int maxHealth = 100;
    public static int swordDamage = 10;
    public static int bowDamage = 10;
    public static int speed = 5;

    public static int healthLvl = 1;
    public static int swordDamageLvl = 1;
    public static int bowDamageLvl = 1;
    public static int speedLvl = 1;

    public TMP_Text coinNum;
    public TMP_Text healthLvll;
    public TMP_Text bowDamageLvll;
    public TMP_Text swordDamageLvll;
    public TMP_Text speedLvll;


    public static int health;
    public static int coins;


    void Start()
    {
        activeCombat = false;
        health = maxHealth;
        coins = 20;

    }

    public void AddHealth()
    {
        if(coins >= 10)
        {
            healthLvl++;
            maxHealth = maxHealth + 25;
            coins = coins - 10;
        }
        
    }

    public void AddSwordDamage()
    {
        if (coins >= 10)
        {
            swordDamageLvl++;
            swordDamage = swordDamage + 10;
            coins = coins - 10;
        }
        
    }

    public void AddBowDamage()
    {
        if (coins >= 10)
        {
            bowDamageLvl++;
            bowDamage = bowDamage + 10;
            coins = coins - 10;
        }
        
    }

    public void AddSpeed()
    {
        if (coins >= 10)
        {
            speedLvl++;
            speed = speed + 1;
            coins = coins - 10;
        }
        
    }

    void Update()
    {
        coinNum.text = coins.ToString();
        healthLvll.text = healthLvl.ToString();
        bowDamageLvll.text = bowDamageLvl.ToString();
        swordDamageLvll.text = swordDamageLvl.ToString();
        speedLvll.text = speedLvl.ToString();

        //Debug.Log(health);
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
            Debug.Log("Dead");
    }
}
