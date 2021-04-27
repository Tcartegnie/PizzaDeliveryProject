using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : Attack
{
    public Transform target;
    public int BeatCount;
    public int BeatCountMax;


	public override void Init(TimerController timer, Grid grid,Transform target)
	{
		base.Init(timer, grid, target);
        timer.onBeat += AddBeat;
        timer.onBeat += CallAttack;
        this.target = target;
        OnBeat = false;
    }
	public void AddBeat()
	{
        if (Vector3.Distance(target.position, transform.position) <= 1)
        {
            if (BeatCount < BeatCountMax)
            {
                BeatCount++;
            }

            if (BeatCount >= 3)
            {
                OnBeat = true;
                BeatCount = 0;
            }
        }
       
	}

    public override void OnDeath()
	{
        base.OnDeath();
        timer.onBeat -= CallAttack;
        timer.onBeat -= AddBeat;
	}

}
