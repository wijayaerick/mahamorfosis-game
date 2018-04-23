using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour {

	public int healthRestored;

	// Use this for initialization
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player")){
            col.gameObject.GetComponent<Player>().IncreaseHealth(healthRestored);
			Destroy(gameObject);
        }
    }
}
