﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public int number;

	void Start() {

	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			PlayerPrefs.SetInt("checkpoint", number);
		}
	}
}
