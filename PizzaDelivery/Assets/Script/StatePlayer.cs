using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer : EntityState
{
	public LifeBar bar;

	public override void Start()
	{
		base.Start();
		bar.Init(PVmax);
	}

	public override void InitLife()
	{
		base.InitLife();
		bar.Init(ActualPV);
	}

	public override void OnDeath()
	{
		base.OnDeath();
		GM.Defeat();
	}

	public override void TakeHit()
	{
		base.TakeHit();
		bar.UpdateLife(ActualPV);
	}
}
