using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

	public GameObject deadUI;
	private Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		deadUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.dead) {
			deadUI.SetActive(true);
		}
	}
}
