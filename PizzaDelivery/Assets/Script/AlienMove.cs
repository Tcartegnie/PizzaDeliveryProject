using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMove : MovingEntity
{
    public MovingEntity Player;
    int BeatCount;
    public int BeatCountMax;
	public override void Init(Vector3 Position, Grid grid, GameManager gM, TimerController controller, MovingEntity Target)
	{
		base.Init(Position, grid, gM, controller, Target);
       this.Player = Target;
        BeatCount = 0;
    }


	public override void OnBeat()
	{
		base.OnBeat();

        if(BeatCount < BeatCountMax)
		{
            BeatCount++;
		}
        else if(BeatCount >= BeatCountMax)
		{
            MoveToPlayer();
            BeatCount = 0;
        }
      

	}
	void MoveToPlayer()
	{

        if (Player.CurrentXPosition - CurrentXPosition > 0)
        {
            MoveCharacter(1, 0, 90);
        }

        else if (Player.CurrentXPosition - CurrentXPosition < 0)
        {
            MoveCharacter(-1, 0, -90);
        }

        if (Player.CurrentZPosition - CurrentZPosition > 0)
        {
            MoveCharacter(0, 1, 0);

        }

        else if (Player.CurrentZPosition - CurrentZPosition < 0)
        {
            MoveCharacter(0, -1, 180);
        }

    }

    public override void OnDeath()
	{
        base.OnDeath();
	}
}
