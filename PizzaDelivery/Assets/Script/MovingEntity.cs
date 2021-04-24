using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public Grid grid;
   
    int CurrentXPosition;
    int CurrentZPosition;

    public Vector2 Position;

    // Start is called before the first frame update
    void Start()
    {
      
        CurrentXPosition = (int)Position.x;
        CurrentZPosition = (int)Position.y;
        ClampPosition();
        transform.position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
    }

    // Update is called once per frame
    

    public void AddPosition(int x, int z)
    {
        CurrentXPosition += x;
        CurrentZPosition += z;
    }

    public void MoveCharacter(int x, int z, float rotate)
	{
        Move(x, z);
        RotatePerso(rotate);
    }

    public void ClampPosition()
    {
        CurrentXPosition = Mathf.Clamp(CurrentXPosition, 0, grid.XgridLenght - 1);
        CurrentZPosition = Mathf.Clamp(CurrentZPosition, 0, grid.ZgridLenght - 1);
    }

    public void Move(int x, int z)
    {
        if (grid.CaseIsWalkable(CurrentXPosition + x, CurrentZPosition + z))
        {
            grid.SetCaseAsWalkable(CurrentXPosition, CurrentZPosition, true);
            AddPosition(x, z);
            ClampPosition();
            transform.position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
            grid.SetCaseAsWalkable(CurrentXPosition, CurrentZPosition, false);
        }
    }

    public void RotatePerso(float Degres)
    {
        transform.eulerAngles = new Vector3(0, Degres, 0);
    }
}
