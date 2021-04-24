using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Case
{
    public Vector3 position;
    public bool IsReachable;
}
public class Grid : MonoBehaviour
{

   public int XgridLenght;
   public int ZgridLenght;
   public int transformOffset;



    Case[,] grid;
       

    public Vector2 GetGridLenght()
	{
        return new Vector2(XgridLenght, ZgridLenght);
	}
 

    public void InitGrid()
	{
        grid = new Case[XgridLenght, ZgridLenght];

        CreatGrid();
    }

    public Vector3 GetCasePosition(int x,int y)
	{
       return grid[x,y].position;
	}

    public bool CaseIsWalkable(int x, int y)
	{
        x = Mathf.Clamp(x, 0, XgridLenght - 1);
        y = Mathf.Clamp(y, 0, ZgridLenght - 1);
        return grid[x, y].IsReachable;
	}

    public void SetCaseAsWalkable(int x, int y, bool value)
    {
        grid[x, y].IsReachable = value;
    }


    public void CreatGrid()
	{
        for (int i = 0; i < XgridLenght; i++)
        {
            for (int j = 0; j < ZgridLenght; j++)
            {
                grid[i, j].position += (transform.position + ((transform.right * transformOffset) * i));
                grid[i, j].position += (transform.position + ((transform.forward * transformOffset) * j));
                grid[i, j].IsReachable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawDebug();
    }

    public void DrawDebug()
	{
        for (int i = 0; i < XgridLenght; i++)
        {
            for (int j = 0; j < ZgridLenght; j++)
            {
                Debug.DrawRay(grid[i,j].position,Vector3.up * 10);
            }
        }
     }

}
