using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCheck : MonoBehaviour {

	private const int GROUND = 0;
	private const int HEAD = 1;
	private const int LEFT = 2;
	private const int RIGHT = 3;
	private Crush[] crush;
	private Player entity;

	void Start () {
		crush = GetComponentsInChildren<Crush>();		
		entity = GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (crush[HEAD].isActive && crush[GROUND].isActive)
		{
			entity.SendMessage("Damage", Mathf.Min(crush[HEAD].ground.crushDamage, crush[GROUND].ground.crushDamage));	
		} 
		else if (crush[LEFT].isActive && crush[RIGHT].isActive)
		{
			entity.SendMessage("Damage", Mathf.Min(crush[LEFT].ground.crushDamage, crush[RIGHT].ground.crushDamage));	
		}
	}


}
