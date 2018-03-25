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

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		camera = GetComponent<CameraFollow>();
		checkpoint = Data.checkPoint;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
