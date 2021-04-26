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
	// Start is called before the first frame update
	public virtual void Start()
	{
        InitEntity();
        controller.onBeat += OnBeat;
	}

	// Update is called once per frame

	public void InitEntity()
	{
        CurrentXPosition = (int)StartPosition.x;
        CurrentZPosition = (int)StartPosition.y;
        ClampPosition();
        transform.position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
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
        if (Gm.CanPlay && CanMove)
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
        CurrentXPosition = Mathf.Clamp(CurrentXPosition, 0, grid.XgridLenght - 1);
        CurrentZPosition = Mathf.Clamp(CurrentZPosition, 0, grid.ZgridLenght - 1);
    }

    public void Move(int x, int z)
    {
        type = grid.GetCaseType(CurrentXPosition + x, CurrentZPosition + z);

        if (grid.GetCaseAccesibility(CurrentXPosition + x, CurrentZPosition + z))
        {
            grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, true);
            AddPosition(x, z);
            ClampPosition();
            transform.position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
            grid.SetCaseAccesibility(CurrentXPosition, CurrentZPosition, false);
        }
    }

    public void RotatePerso(float Degres)
    {
        transform.eulerAngles = new Vector3(0, Degres, 0);
    }

    public void OnBeat()
	{
        Beat = true;
    }

    public virtual void OnDeath()
	{
        CanMove = false;
        SetCurrentAccesibility(true);
    }
}
