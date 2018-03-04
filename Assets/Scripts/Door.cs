using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Vector3 newPosition;

    void Start()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.position = newPosition;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.position = newPosition;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
        }
    }
}
