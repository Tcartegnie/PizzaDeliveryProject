using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public int ScoreOnDeath;
    public int PVmax;
    public int ActualPV;
    public Attack attack;
    public MovingEntity move;
    public Grid grid;
    public GameManager GM;
    // Start is called before the first frame update
    public virtual void Start()
    {
        InitLife();
    }

    public void Init(Grid grid, GameManager GM)
	{
        this.grid = grid;
        this.GM = GM;
    }

    public virtual void InitLife()
    {
        ActualPV = PVmax;
    }

    public virtual void TakeHit()
	{
        ActualPV -= 1;
        CheckPV();
	}

    public void CheckPV()
	{
        if(ActualPV <= 0)
		{
            OnDeath();
            
		}
	}

    public virtual void OnDeath()
	{
        attack.OnDeath();
        move.OnDeath();
        if (gameObject.tag != "Player")
		{
            GM.AddMultiplicator();
            GM.AddScore(ScoreOnDeath);
            grid.removeEntity(gameObject);
            Destroy(gameObject);
        }
   
 
   
	}
}
