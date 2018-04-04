using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {

	public Camera camera;
	public AudioClip bossMusic;
	private Collider2D collider;
	public Vector3 minCamera, maxCamera;


	// Use this for initialization
	void Start () {
		collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag("Player")) {
			collider.isTrigger = false;
			camera.GetComponents<AudioSource>()[0].clip = bossMusic;
			camera.GetComponents<AudioSource>()[0].loop = true;
			camera.GetComponents<AudioSource>()[0].volume = 0.4f;
			camera.GetComponents<AudioSource>()[0].Play();
			camera.GetComponent<CameraFollow>().minCameraPos = minCamera;
			camera.GetComponent<CameraFollow>().maxCameraPos = maxCamera;
		}		
	}
}
