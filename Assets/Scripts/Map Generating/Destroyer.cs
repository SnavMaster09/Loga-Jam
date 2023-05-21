using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag != "Enemy")
            {
                if ((collision.gameObject.tag != "SpiderBullet"))
                {
                    if ((collision.gameObject.tag != "CombatDetection"))
                        if ((collision.gameObject.tag != "Sword"))
                        {
                            Destroy(collision.gameObject);
                        }
                }
            }
        }
        
    }
}
