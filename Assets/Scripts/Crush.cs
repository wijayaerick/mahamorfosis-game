using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour {

	public bool isActive = false;
	public Ground ground;

	// public enum SideType {GROUND, HEAD, LEFT, RIGHT};
	// public SideType side;

	// void OnCollisionEnter2D (Collision2D col)
	// {
	// 	if (col.gameObject.tag == "Ground")
	// 	{
	// 		if (col.gameObject.GetComponent<Ground>().canCrush)
	// 		{
	// 			Collider2D collider = col.collider;
	// 			Vector3 contactPoint = col.contacts[0].point;
	// 			Vector3 center = collider.bounds.center;
	// 			Debug.Log(contactPoint + " " + center);

	// 			if((side == SideType.GROUND && contactPoint.y < center.y) ||
	// 			(side == SideType.HEAD && contactPoint.y > center.y) ||
	// 			(side == SideType.LEFT && contactPoint.x < center.x) ||
	// 			(side == SideType.RIGHT && contactPoint.x > center.x))
	// 			{
	// 				ground = col.gameObject.GetComponent<Ground>();
	// 				isActive = true;
	// 			// }
	// 		}
	// 	}
	// }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Ground"))
		{
			if (col.GetComponent<Ground>().canCrush){
				ground = col.GetComponent<Ground>();
				isActive = true;
			}
		}
	}
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.CompareTag("Ground"))
		{
			isActive = false;
		}
	}
}
