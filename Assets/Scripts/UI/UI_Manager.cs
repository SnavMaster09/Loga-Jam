using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{

    public Animator anim;

    private bool open;

    void Start()
    {
        open = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            open = !open;
        anim.SetBool("isOpen", open);

    }
}
