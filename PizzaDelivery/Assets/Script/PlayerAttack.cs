using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
	public float CoolDownAttack;
    float CurrentCoolDownAttack;
	public AudioSource HitSource;
	public AudioClip HitClip;

    void Start()
    {
        OnBeat = true;
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (timer.IsNearBeat())
			{
				CallAttack();
				HitSource.PlayOneShot(HitClip);
			}
		}
	}


}
