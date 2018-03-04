using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerController pc;

    void Start()
    {
        pc = gameObject.GetComponentInParent<PlayerController>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            pc.grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            pc.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        pc.grounded = false;
    }

}
