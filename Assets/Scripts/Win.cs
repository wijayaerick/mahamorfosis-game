using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	private Player player;
	public GameObject winUI;
	public Image[] stars;
	public Text time;
	public Text score; 
	public bool invoked = false;

	// Use this for initialization
	void Start () {
		winUI.SetActive(false);
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.win && !invoked) {
			invoked = true;

			PlayerPrefs.SetInt("checkpoint", -1);
			winUI.SetActive(true);

			float bestPlayTime = 500.0F;
			float scoreModifier = (bestPlayTime / Data.playTime) * (2 * (float)(Data.score) / (float)(Data.totalEnemyPower));
			int finalScore = Convert.ToInt32(Math.Round(Data.score * scoreModifier));

			Data.finalScore = finalScore;

			time.text = Data.playTime.ToString();
			score.text = Data.finalScore.ToString();

			if (finalScore >= 5000) {

			} else if (finalScore >= 3000) {
				stars[2].gameObject.SetActive(false);
			} else if (finalScore >= 1500) {
				stars[2].gameObject.SetActive(false);
				stars[1].gameObject.SetActive(false);
			} else {
				stars[2].gameObject.SetActive(false);
				stars[1].gameObject.SetActive(false);
				stars[0].gameObject.SetActive(false);
			}
		}
	}

	public void RestartFromScratch() {
		Data.score = 0;
		Data.playTime = 0.0F;
		Data.totalEnemyPower = 0;

		SceneManager.LoadScene(1);
	}
}
