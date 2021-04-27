using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public Grid grid;
   
   public int CurrentXPosition;
    public int CurrentZPosition;

    public Vector2 StartPosition;
    protected CaseType type;

    public GameManager Gm;

    bool CanMove;
    public bool Beat;
    public TimerController controller;
    public Animator anim;
	// Start is called before the first frame update
    public virtual void Start()
	{
        if (gameObject.tag == "Player")
		{
            controller.onBeat += OnBeat;
            InitEntity();
        }
	}

	// Update is called once per frame
    public virtual void Init(Vector3 Position,Grid grid,GameManager gM, TimerController controller, Transform Target)
	{
        this.grid = grid;
        Gm = gM;
        StartPosition = new Vector2(Position.x,Position.z);
        this.controller = controller;
        this.controller.onBeat += OnBeat;
        InitEntity();
	}
	public void InitEntity()
	{
        CurrentXPosition = (int)StartPosition.x;
        CurrentZPosition = (int)StartPosition.y;
        ClampPosition();
        transform.position = new Vector3(grid.GetCasePosition(CurrentXPosition, CurrentZPosition).x,-1, grid.GetCasePosition(CurrentXPosition, CurrentZPosition).z);
        type = grid.GetCaseType(CurrentXPosition, CurrentZPosition);
        CanMove = true;
    }
    public void AddPosition(int x, int z)
    {
        CurrentXPosition += x;
        CurrentZPosition += z;
    }

    public virtual void MoveCharacter(int x, int z, float rotate)
	{
        if (Gm.CanPlay && CanMove && Beat)
        {
            Move(x, z);
            RotatePerso(rotate);
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
        type = grid.GetCaseType(CurrentXPosition + x, CurrentZPosition + z);

        if (grid.GetCaseAccesibility(CurrentXPosition + x, CurrentZPosition + z))
        {
            grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, true);
            AddPosition(x, z);
            ClampPosition();
            transform.position = new Vector3(grid.GetCasePosition(CurrentXPosition, CurrentZPosition).x,-1, grid.GetCasePosition(CurrentXPosition, CurrentZPosition).z);
            grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, false);
            anim.SetTrigger("Move");
        }
        Beat = false;
    }

    public void SetCharacterPosition(int x, int y)
	{
       transform.position = grid.GetCasePosition(x, y);
        CurrentXPosition = x;
        CurrentZPosition = y;

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
        controller.onBeat -= OnBeat;
    }
}
