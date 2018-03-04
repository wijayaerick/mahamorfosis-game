using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] heartSprites;
    public Image heartUI;
    private PlayerController pc;

	void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void Update () {
        heartUI.sprite = heartSprites[pc.curHealth];
	}
}
