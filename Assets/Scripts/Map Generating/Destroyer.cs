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
                    Destroy(collision.gameObject);
                }
            }
        }
        
    }
}
