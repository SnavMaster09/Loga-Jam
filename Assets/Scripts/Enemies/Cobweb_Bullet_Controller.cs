using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobweb_Bullet_Controller : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public int bulletDamage = 10;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindAnyObjectByType<Player_Manager>().takeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
