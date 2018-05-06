using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Player player;
    public Slider slider;
    public Image visualHealth;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}
	
    void Update () {
        HandleHealth();
    }

    private void HandleHealth() {
        slider.value = (float) player.curHealth / player.maxHealth;

        if (player.curHealth > player.maxHealth / 2) {
            visualHealth.color = new Color32(0, 135, 46, 255);
        }
        else if (player.curHealth > player.maxHealth / 4) {
            visualHealth.color = new Color32(234, 255, 41, 255);
        }
        else {
            visualHealth.color = new Color32(255, 41, 41, 255);
        }
    }


}
