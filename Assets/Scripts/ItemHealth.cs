using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour {

	public int healthRestored;
    private AudioSource audio;
    private bool touched = false;

	void Start() {
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
            audio.Play();
            col.gameObject.GetComponent<Player>().IncreaseHealth(healthRestored);
            touched = true;
        }
    }
}
