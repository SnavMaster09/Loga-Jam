using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Controller : MonoBehaviour
{
    public bool isAttacking;

    private void Start()
    {
        isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log(1);
    }
}
