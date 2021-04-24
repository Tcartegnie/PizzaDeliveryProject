using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
	public float CoolDownAttack;
    float CurrentCoolDownAttack;

    void Start()
    {
		timer.onBeat += AttackCall;
        CanAttack = true;
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CallAttack();
		}
	}

	private void FixedUpdate()
	{


		if(CurrentCoolDownAttack > 0)
		{
			CurrentCoolDownAttack -= Time.deltaTime;
		}
		else
		{
			CanAttack = false;
		}
	}

	void AttackCall()
	{
		CanAttack = true;
		CurrentCoolDownAttack = CoolDownAttack;
	}
}
