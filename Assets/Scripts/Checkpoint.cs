using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int number;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			GameObject.FindObjectOfType<Camera>().GetComponent<Level1>().checkpoint = number;
		}
	}
}
