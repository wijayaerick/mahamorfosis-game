using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

    public TurretController tc;
    public bool isLeft = false;

    void Awake ()
    {
        tc = GetComponentInParent<TurretController>();
    }

    void OnTriggerStay2D (Collider2D col)
    {
		if (col.CompareTag("Player"))
        {
            tc.Attack(!isLeft);
        }
	}
	
}
