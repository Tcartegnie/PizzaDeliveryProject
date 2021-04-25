using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CaseType
{
    Empty,
    Blocked,
    Exit,
}
public struct Case
{
    public Vector3 position;
    public CaseType type;
    public bool IsReachable;
}
public class Grid : MonoBehaviour
{

   public int XgridLenght;
   public int ZgridLenght;
   public int transformOffset;

   public GameObject Cube;

    List<GameObject> Cases = new List<GameObject>();

    Case[,] grid;
    public Vector2 VictoryGrid;

    public Vector2 GetGridLenght()
	{
        return new Vector2(XgridLenght, ZgridLenght);
	}

	public void Start()
	{
        InitGrid();
	}

	public void DestroyGrid()
    { 	

        for(int i = 0; i < Cases.Count;i++)
		{
            GameObject GO = Cases[i];
            Cases.Remove(GO);
            Destroy(GO);
        }
  

        Cases.Clear();
	}

	public void InitGrid()
	{
        DestroyGrid();

        grid = new Case[XgridLenght, ZgridLenght];

        CreatGrid();
    }

    public Vector3 GetCasePosition(int x,int y)
	{
       return grid[x,y].position;
	}

    public CaseType GetCaseType(int x, int y)
	{
        x = Mathf.Clamp(x, 0, XgridLenght - 1);
        y = Mathf.Clamp(y, 0, ZgridLenght - 1);
        return grid[x, y].type;
	}

    public bool GetCaseAccesibility(int x, int y)
    {
        x = Mathf.Clamp(x, 0, XgridLenght - 1);
        y = Mathf.Clamp(y, 0, ZgridLenght - 1);
        return grid[x, y].IsReachable;
    }

    public void SetCaseAccesibility(int x, int y, bool value)
    {
        x = Mathf.Clamp(x, 0, XgridLenght - 1);
        y = Mathf.Clamp(y, 0, ZgridLenght - 1);
        grid[x, y].IsReachable = value;
    }

    public void SetCaseType(int x, int y, CaseType value)
    {
        grid[x, y].type = value;
    }


    public void CreatGrid()
	{
        for (int i = 0; i < XgridLenght; i++)
        {
            for (int j = 0; j < ZgridLenght; j++)
            {
                grid[i, j].position += (transform.position + ((transform.right * transformOffset) * i));
                grid[i, j].position += (transform.position + ((transform.forward * transformOffset) * j));
                grid[i, j].type = CaseType.Empty;
                grid[i, j].IsReachable = true;
                GameObject go = Instantiate(Cube,transform.position + ((transform.right * i) + transform.forward * j) -transform.up, new Quaternion());
                Cases.Add(go);
            }
        }

        grid[(int)VictoryGrid.x,(int)VictoryGrid.y].type = CaseType.Exit;
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
