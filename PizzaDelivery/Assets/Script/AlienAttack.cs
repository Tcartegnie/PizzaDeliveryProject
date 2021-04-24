using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : Attack
{
    public Transform target;
    public int BeatCount;
    public int BeatCountMax;
    void Start()
    {
        timer.onBeat += CallAttack;
        timer.onBeat += AddBeat;
        CanAttack = false;
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
                CanAttack = true;
                BeatCount = 0;
            }
        }
       
	}



}
