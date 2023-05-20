using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Shooter : MonoBehaviour
{
    public Spider_Controller spiderControllerScript;

    private bool canShoot;

    public Transform spider;

    public GameObject bullet;

    private float timer;

    //public Transform shootPos;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spiderControllerScript.state != Spider_Controller.State.idle)
            canShoot = false;

        if(canShoot == true)
        {
            
            if(timer > 3)
            {
                timer = 0;
                Debug.Log(1);
                Shoot();
            }
        }


        transform.position = spider.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        if (spiderControllerScript.state == Spider_Controller.State.idle)
            canShoot = true;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (spiderControllerScript.state == Spider_Controller.State.idle)
            canShoot = false;
    }

    private void Shoot()
    {
        Instantiate(bullet,transform.position, transform.rotation);
    }




}
