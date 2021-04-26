using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour
{

    public MovingEntity entity;
    public TimerController timer;
    public Grid grid;
    public LayerMask RayCastMask;
    public bool OnBeat = true;
    public bool CanAttack = true;

    public void Init(TimerController timer, Grid grid)
	{
        this.timer = timer;
        this.grid = grid;
	}

	public void CallAttack()
	{
        if (CanAttack && timer.IsNearBeat())
        {
            CheckCase();
        }
    }

    void CheckCase() 
	{
        RaycastHit HitInfo = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.forward);
          
        if(Physics.Raycast(ray,out HitInfo,10f,RayCastMask))
		{
            if (HitInfo.transform.GetComponentInParent<EntityState>() != null)
            {
                HitInfo.transform.GetComponentInParent<EntityState>().TakeHit();
            }
		}
	}

    public virtual void OnDeath()
    {
        CanAttack = false;
    }

}
