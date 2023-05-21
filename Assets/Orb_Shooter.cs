using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Shooter : MonoBehaviour
{

    private bool canShoot;

    private float timer;

    public GameObject orb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (canShoot == true)
        {
            if (timer > 3)
            {
                timer = 0;

                Shoot();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        canShoot = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        canShoot = false;
    }

    private void Shoot()
    {
        Instantiate(orb, transform.position, transform.rotation);
    }
}
