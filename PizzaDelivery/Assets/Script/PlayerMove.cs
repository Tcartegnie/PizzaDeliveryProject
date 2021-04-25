using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MovingEntity
{
	public override void Start()
	{
		base.Start();
	}
	public override void MoveCharacter(int x, int z, float rotate)
	{
		base.MoveCharacter(x, z,rotate);
		if (type == CaseType.Exit)
		{
			Gm.Victory();
		}
	}
}
