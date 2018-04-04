using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

	private RectTransform rt;
	private float time = 20f, curTime;
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y + 0.7f);
		if (curTime > time) {
			Application.LoadLevel(1);
		}
	}
}
