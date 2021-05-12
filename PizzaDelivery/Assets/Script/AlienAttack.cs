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
        this.target = target;
        OnBeat = false;
    }
	public void AddBeat()
	{
        if (Vector3.Distance(target.position, transform.position) <= 1.2f)
        {
            if (BeatCount < BeatCountMax)
            {
                BeatCount++;
            }

            if (BeatCount >= BeatCountMax)
            {
                CanAttack = true;
                OnBeat = true;
                CallAttack();
                BeatCount = 0;
            }
        }
       
	}

	private void OnDestroy()
	{
        OnDeath();
        timer.onBeat -= AddBeat;
    }
}
