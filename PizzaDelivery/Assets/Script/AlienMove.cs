using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MovingEntity
{
    public Transform target;


	public override void Init(Vector3 Position, Grid grid, GameManager gM, TimerController controller, Transform Target)
	{
		base.Init(Position, grid, gM, controller,target);
       this.target = Target;
	}

	void MoveToPlayer()
	{

        if (target.position.x - transform.position.x > 0)
        {
            MoveCharacter(1, 0, 90);
        }

        else if (target.position.x - transform.position.x < 0)
        {
            MoveCharacter(-1, 0, -90);
        }

        if (target.position.z - transform.position.z > 0)
        {
            MoveCharacter(0, 1, 0);

        }

        else if (target.position.z - transform.position.z < 0)
        {
            MoveCharacter(0, -1, 180);
        }

    }

    public override void OnDeath()
	{
        base.OnDeath();
        controller.onBeat -= MoveToPlayer;
	}
}
