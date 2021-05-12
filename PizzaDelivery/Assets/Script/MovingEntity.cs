using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public Grid grid;
   
    public int CurrentXPosition;
    public int CurrentZPosition;

    protected CaseType type;

    public GameManager Gm;

    bool CanMove;
    public bool Beat;
    public TimerController controller;
    public Animator anim;
    public float TranstionTime;
    public PlayerParticleCaller particlCallser;
	// Start is called before the first frame update
  
	// Update is called once per frame
    public virtual void Init(Vector3 Position,Grid grid,GameManager gM, TimerController controller, MovingEntity Target)
	{
        this.grid = grid;
        Gm = gM;
        CurrentXPosition = (int)Position.x;
        CurrentZPosition = (int)Position.z;
        this.controller = controller;
        this.controller.onBeat += OnBeat;
        InitEntity();
	}
	public void InitEntity()
	{
        ClampPosition();
        type = grid.GetCaseType(CurrentXPosition, CurrentZPosition);
        CanMove = true;
    }
   
    public virtual void MoveCharacter(int x, int z, float rotate)
	{
        if (Gm.CanPlay && CanMove)
        {
            Move(CurrentXPosition + x, CurrentZPosition + z);
            RotatePerso(rotate);
        }
    }

    public void MoveOnRandomPoint()
	{
        int x = Random.Range(0,(int)grid.GetGridLenght().x);
        int y = Random.Range(0,(int)grid.GetGridLenght().y);

        if(grid.GetCaseAccesibility(x,y))
		{
            SetCharacterPositionData(x,y);
            SetCharacterPosition();
		}
        else
		{
            MoveOnRandomPoint();
		}
	}

    public void SetCUrrentCaseType(CaseType type)
    {
        grid.SetCaseType(CurrentXPosition, CurrentZPosition, type);
    }

    public void SetCurrentAccesibility(bool value)
    {
        grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, value);
    }


    public void ClampPosition()
    {
        CurrentXPosition = Mathf.Clamp(CurrentXPosition, 0, (int)grid.GetGridLenght().x - 1);
        CurrentZPosition = Mathf.Clamp(CurrentZPosition, 0, (int)grid.GetGridLenght().y - 1);
    }

    public void Move(int x, int z)
    {
        if (grid.GetCaseAccesibility(x,z))
        {
            SetCharacterPositionData(x, z);



            StartCoroutine(Transition());

            anim.SetTrigger("Move");
        }
        Beat = false;
    }

    public void SetCharacterPositionData(int x, int z)
	{
        grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, true);
        grid.SetCaseAccesibility(x, z, false);

        CurrentXPosition = x;
        CurrentZPosition = z;

        type = grid.GetCaseType(CurrentXPosition, CurrentZPosition);

        ClampPosition();


    }

    public void SetCharacterPosition()
	{
        Vector3 position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
        transform.position = new Vector3(position.x,-1, position.z);
    }

    public void RotatePerso(float Degres)
    {
        transform.eulerAngles = new Vector3(0, Degres, 0);
    }

    public virtual void OnBeat()
	{
        Beat = true;
    }

    public virtual void OnDeath()
	{
        CanMove = false;
        SetCurrentAccesibility(true);
    }

	private void OnDestroy()
	{
        controller.onBeat -= OnBeat;
    }

	public IEnumerator Transition()
	{
        Vector3 Depart = transform.position;
        Vector3 arrival = new Vector3(grid.GetCasePosition(CurrentXPosition,CurrentZPosition).x,-1, grid.GetCasePosition(CurrentXPosition, CurrentZPosition).z); 
        for(float i = 0; i < 1f; i+= Time.deltaTime/TranstionTime)
		{
            transform.position = Vector3.Lerp(Depart, arrival, i);
            if (i >= (Time.deltaTime / TranstionTime) / 2)
			{
                particlCallser.CallWalkParticle();
            }
            yield return null;
		}
	}
}
