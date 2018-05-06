using System;
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

			float bestPlayTime = 300.0F;
			float scoreModifier = (bestPlayTime / Data.playTime) * (2 * (float)(Data.score) / (float)(Data.totalEnemyPower));
			int finalScore = Convert.ToInt32(Math.Round(Data.score * scoreModifier));

			Data.finalScore = finalScore;
			//Debug.Log ("Time : " + Data.playTime + "\tScore : " + Data.score + "\tTotal Enemy Power : " + Data.totalEnemyPower + "\nFinal score : " + finalScore);
		}
	}
}
