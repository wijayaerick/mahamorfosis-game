using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MobilePlatform : MonoBehaviour {

	public GameObject mobileUI;
	private bool isMobile;
	private Pause pause;
	private Player player;
	private PlayerAttack playerAttack;
	private bool shooting = false;
	private bool ulting = false;

	void Start () {
		#if UNITY_IOS
			isMobile = true;
		#elif UNITY_ANDROID
			isMobile = true;
		#elif UNITY_EDITOR
			isMobile = false;
		#else
			isMobile = false;
		#endif
		pause = GetComponent<Pause>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
	}
	
	void Update () {
		if (pause.isPaused()){
			mobileUI.SetActive(false);
		}
		else {
			mobileUI.SetActive(isMobile);
		}

		if (shooting && !playerAttack.attacking) {
			playerAttack.Shoot();
		} else if (ulting && !playerAttack.attacking) {
			playerAttack.Ulti();
		}
	}

	public void MoveLeft(){
		player.inputHorizontal = -1;
	}

	public void MoveRight(){
		player.inputHorizontal = 1;
	}

	public void MoveUp(){
		player.inputVertical = 1;
	}

	public void MoveDown(){
		player.inputVertical = -1;
	}

	public void ReleaseHorizontal(){
		player.inputHorizontal = 0;
	}

	public void ReleaseVertical(){
		player.inputVertical = 0;
	}

	public void Jump(){
		player.Jump();
	}

	public void Shoot(){
		shooting = true;
	}

	public void Ulti(){
		ulting = true;
	}

	public void ReleaseShoot(){
		shooting = false;
		ulting = false;
	}

	public void Interact(){

	}


}
