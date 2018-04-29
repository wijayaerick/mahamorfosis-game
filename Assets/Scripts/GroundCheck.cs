using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            player.grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!col.isTrigger)
        {
            player.grounded = true;
        }

        if (col.gameObject.tag == "Ground"){
            Ground g = col.gameObject.GetComponent<Ground>();
            if (g.canMove || g.canFall)
            player.transform.parent = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;

        if (col.gameObject.tag == "Ground"){
            player.transform.parent = null;
        }
    }

}
