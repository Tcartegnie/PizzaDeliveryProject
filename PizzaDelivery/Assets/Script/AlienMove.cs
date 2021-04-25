using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MovingEntity
{
    public Transform target;
    public TimerController timer;

	public override void Start()
	{
        base.Start();
        timer.onBeat += MoveToPlayer;
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
       // timer.onBeat -= MoveToPlayer;
	}
}
