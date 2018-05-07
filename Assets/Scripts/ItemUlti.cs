using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUlti : MonoBehaviour {

	public int ultiRestored = 1;
	private Player player;
	private AudioSource audio;
	private bool touched = false;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		audio = GetComponent<AudioSource>();
	}

	void Update() {
		if (touched) {
			if (!audio.isPlaying) {
				Destroy(gameObject);
			}
		}
	}

	// Use this for initialization
    void OnTriggerEnter2D (Collider2D col)
    {
        if (!touched && col.CompareTag("Player")){
			GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
			if (player.ulti < 3) {
				audio.Play();
				if (player.ulti + ultiRestored > 3) {
					player.ulti = 3;
				} else {
					player.ulti += ultiRestored;
				}
			}
			touched = true;
        }
    }
}
