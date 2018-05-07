using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	private RectTransform rt;
	private Text[] texts;
	private float curTime = 0;
	private int index = 0;
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
		texts = GetComponentsInChildren<Text>();
		for (int i = 0; i < texts.Length - 1; i++) {
			texts[i].gameObject.SetActive(false);
		}
		texts[0].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		if (curTime > 2f) {
			curTime = 0;
			index++;
			if (index >= texts.Length - 1) {
				Debug.Log("Done");
				SceneManager.LoadScene(3);
			} 
			else {
				texts[index-1].gameObject.SetActive(false);
				texts[index].gameObject.SetActive(true);
			}
		}
	}

	public void Skip() {
		texts[index-1].gameObject.SetActive(false);
		texts[index].gameObject.SetActive(false);
		index = texts.Length - 1;
	}
}
