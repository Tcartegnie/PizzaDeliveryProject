using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{
	public float CoolDownAttack;
    float CurrentCoolDownAttack;
	public AudioSource HitSource;
	public AudioClip HitClip;
	public GameManager GM;

    void Start()
    {
        OnBeat = true;
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CallAttack();
			HitSource.PlayOneShot(HitClip);
			if (timer.IsNearBeat())
			{
				CanAttack = true;
			}
			else
			{
				GM.RestMultiplicator();
			}
		}
	}


}
