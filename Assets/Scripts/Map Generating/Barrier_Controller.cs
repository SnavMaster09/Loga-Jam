using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Controller : MonoBehaviour
{


    public GameObject boulders;

    // Update is called once per frame
    void Update()
    {
        if (Player_Manager.activeCombat == false)
            boulders.SetActive(false);
        else if (Player_Manager.activeCombat == true)
            boulders.SetActive(true);
    }
}
