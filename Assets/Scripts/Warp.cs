using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour {

    public Vector3 newPosition;

    void Start()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                col.transform.position = newPosition;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                col.transform.position = newPosition;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
        }
    }
}
