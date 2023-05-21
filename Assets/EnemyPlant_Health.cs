using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant_Health : MonoBehaviour
{
    private int maxHealth = 25;
    private int health = 25;
    public int coins;


    public EnenyPlant_Controller enemyPlantControllerScript;

    private void Start()
    {

    }

    private void Update()
    {

    }

    

    private void Die()
    {

        Player_Manager.coins += coins;
        Destroy(gameObject);

    }
}
