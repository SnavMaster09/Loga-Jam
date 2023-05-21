using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Player_Movement_Controller.lastDir == 2)
            rb.velocity = new Vector2(0, force);
        else if (Player_Movement_Controller.lastDir == 1)
            rb.velocity = new Vector2(0, -force);
        else if (Player_Movement_Controller.lastDir == 3)
            rb.velocity = new Vector2(-force, 0);
        else if (Player_Movement_Controller.lastDir == 4)
            rb.velocity = new Vector2(force, 0);
        else if (Player_Movement_Controller.lastDir == 5)
            rb.velocity = new Vector2(-force, force);
        else if (Player_Movement_Controller.lastDir == 6)
            rb.velocity = new Vector2(force, force);
        else if (Player_Movement_Controller.lastDir == 7)
            rb.velocity = new Vector2(-force, -force);
        else if (Player_Movement_Controller.lastDir == 8)
            rb.velocity = new Vector2(force, -force);

    }

    //1=front 2=back 3=left 4=right 5=frontleft 6=frontright 7=backleft 8=backright
    private void Update()
    {
        

    }
}
