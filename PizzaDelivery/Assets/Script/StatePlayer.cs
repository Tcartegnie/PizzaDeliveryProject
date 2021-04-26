using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer : EntityState
{
	public override void OnDeath()
	{
		base.OnDeath();
		GM.Defeat();
	}
}
