using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public int PVmax;
    public int ActualPV;
    public Attack attack;
    public MovingEntity move;
    public Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        ActualPV = PVmax;
    }

   public void TakeHit()
	{
        ActualPV -= 1;
        CheckPV();
	}

    public void CheckPV()
	{
        if(ActualPV <= 0)
		{
            OnDeath();
            gameObject.SetActive(false);
		}
	}

    public virtual void OnDeath()
	{
        attack.OnDeath();
        move.OnDeath();
	}
}
