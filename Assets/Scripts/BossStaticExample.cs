using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStaticExample : EnemyStatic {

	public override void Die() 
	{
		Application.LoadLevel(0);
	}
}
