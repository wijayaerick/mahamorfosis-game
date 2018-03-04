using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour {

    private PlayerController pc;

	void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("Player"))
        {
            pc.Damage(3);
            StartCoroutine(pc.Knockback(0.02f, new Vector2(100, 350)));
        }
	}
}
