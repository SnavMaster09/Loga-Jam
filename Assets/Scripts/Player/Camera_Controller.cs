using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x - transform.position.x <= -7)
        {
            transform.position = new Vector3(transform.position.x - 14, transform.position.y, -25);
            player.position = new Vector3(player.position.x - 2, player.position.y, 0);
        }
        if (player.position.x - transform.position.x >= 7)
        {
            transform.position = new Vector3(transform.position.x + 14, transform.position.y, -25);
            player.position = new Vector3(player.position.x + 2, player.position.y, 0);
        }
        if (player.position.y - transform.position.y <= -7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 14, -25);
            player.position = new Vector3(player.position.x, player.position.y - 2, 0);
        }
        if (player.position.y - transform.position.y >= 7)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 14, -25);
            player.position = new Vector3(player.position.x, player.position.y + 2, 0);
        }

    }
}
