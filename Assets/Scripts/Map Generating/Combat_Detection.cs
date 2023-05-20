using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player_Manager.activeCombat);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Player_Manager.activeCombat = false;
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Player_Manager.activeCombat = true;
    }
}
