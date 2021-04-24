using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MonoBehaviour
{
    public Transform target;
    public MovingEntity entity;
    public TimerController timer;


	private void Start()
	{
        timer.onBeat += MoveToPlayer;
	}

	void MoveToPlayer()
	{

        if (target.position.x - transform.position.x > 0)
        {
            entity.MoveCharacter(1, 0, 90);
        }

        else if (target.position.x - transform.position.x < 0)
        {
            entity.MoveCharacter(-1, 0, -90);
        }

        if (target.position.z - transform.position.z > 0)
        {
            entity.MoveCharacter(0, 1, 0);

        }

        else if (target.position.z - transform.position.z < 0)
        {
            entity.MoveCharacter(0, -1, 180);
        }

    }
}
