using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoss2GroundCheck : MonoBehaviour
{

    private NoodleBoss2 boss;

    void Start()
    {
        boss = gameObject.GetComponentInParent<NoodleBoss2>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            boss.grounded = true;
            Debug.Log("grounded");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            boss.grounded = true;
        }

        if (col.gameObject.tag == "Ground")
        {
            Ground g = col.gameObject.GetComponent<Ground>();
            if (g.canMove || g.canFall)
                boss.transform.parent = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        boss.grounded = false;

        if (col.gameObject.tag == "Ground")
        {
            boss.transform.parent = null;
        }
    }

}
