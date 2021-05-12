using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    hit,
    teleportation
}
public class Attack : MonoBehaviour
{

    public MovingEntity entity;
    public TimerController timer;
    public Grid grid;
    public LayerMask RayCastMask;
    public bool OnBeat = true;
    public bool CanAttack = true;
    public Animator anim;
    public AttackType attackType;
    public virtual void Init(TimerController timer, Grid grid, Transform target)
	{
        this.timer = timer;
        this.grid = grid;
   
        CanAttack = true;
    }

	public void CallAttack()
	{
        if (CanAttack && OnBeat)
        {
            GameObject target;
            if(CheckCase(out target))
			{
                PlayAttackEffect(target);
            }
        }
    }

    protected bool CheckCase(out GameObject target) 
	{
        RaycastHit HitInfo = new RaycastHit();
        Ray ray = new Ray(transform.position, transform.forward);
          
        if(Physics.Raycast(ray,out HitInfo,10f,RayCastMask))
		{
            if (HitInfo.transform.GetComponentInParent<EntityState>() != null)
            {
                target = HitInfo.transform.gameObject;
                return true;
            }
		}
        target = null;
        return false;
	}

    public void PlayAttackEffect(GameObject target)
	{
        switch(attackType)
		{
            case AttackType.hit:
                HitEffect(target);
                return;
            case AttackType.teleportation:
                Teleporation(target);
                return;
        }
	}

    public void HitEffect(GameObject target)
	{
        target.GetComponentInParent<EntityState>().TakeHit();
        anim.SetTrigger("Attack");
        CanAttack = false;
    }

    public void Teleporation(GameObject target)
	{
        target.GetComponentInParent<MovingEntity>().MoveOnRandomPoint();
    }

    public virtual void OnDeath()
    {
        CanAttack = false;
    }

}
