using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

	private Player player;
	private CameraFollow camera;
	public int checkpoint;
	public float time, lastTime;
	public int score, lastScore;
	public int money, lastMoney;
	public Vector2[] checkpoints;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		camera = GetComponent<CameraFollow>();
		checkpoint = PlayerPrefs.GetInt("checkpoint", -1);

		if (checkpoint != -1) {
			player.transform.position = checkpoints[checkpoint];
		}
	}
	
	// Update is called once per frame
	void Update () {
		Data.playTime += Time.deltaTime;
	}
}
