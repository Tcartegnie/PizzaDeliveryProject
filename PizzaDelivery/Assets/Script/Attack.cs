﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{

    public MovingEntity entity;
    public TimerController timer;
    public Grid grid;
    public LayerMask RayCastMask;
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
            CallAttack();
		}
	}

	public void CallAttack()
	{
        CheckCase();
    }

    void CheckCase() 
	{
        RaycastHit HitInfo = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.forward);
          
        if(Physics.Raycast(ray,out HitInfo,10f,RayCastMask))
		{
            if (HitInfo.transform.GetComponentInParent<Attack>() != null)
            {
               Destroy(HitInfo.transform.gameObject);
            }
		}
	}



}