using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class PlayerMove : MovingEntity
{
	public void Start()
	{
		controller.onBeat += OnBeat;
	}
	public override void Init(Vector3 Position, Grid grid, GameManager gM, TimerController controller, MovingEntity Target)
	{
		base.Init(Position, grid, gM, controller, Target);
	}
	public override void MoveCharacter(int x, int z, float rotate)
	{
			base.MoveCharacter(x, z, rotate);
			if (type == CaseType.Exit)
			{
				Gm.Victory();
				type = CaseType.Empty;
			}
	}

}
