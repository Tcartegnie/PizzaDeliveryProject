using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : Attack
{

    int BeatCount;
    void Start()
    {
        timer.onBeat += CallAttack;
        timer.onBeat += AddBeat;
    }

    public void AddBeat()
	{
        if(BeatCount < 3)
		{
            BeatCount++;
		}

        if(BeatCount >= 3)
		{
            CanAttack = true;
            BeatCount = 0;
		}
       
	}



}
