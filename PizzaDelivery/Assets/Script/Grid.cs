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

   public int transformOffset;

   public GameObject Cube;

    public List<SOBJroom> Rooms = new List<SOBJroom>();
    SOBJroom CurrentRoom;
    List<GameObject> Cases = new List<GameObject>();
    public SOBJroom VisoRoom;
    Case[,] grid;
    public Vector2 VictoryGrid;
    public bool Visibility;

    public Factory factory;
    public Vector2 GetGridLenght()
	{
        return new Vector2((int)CurrentRoom.GridLenght.x,(int)CurrentRoom.GridLenght.y);
	}

	public void Awake()
	{
        if (!Visibility)
        {
            InitGrid();
        }
        else
		{
            CurrentRoom = VisoRoom;
            DestroyGrid();
            CreatGrid(CurrentRoom);
		}
	}

	public void DestroyGrid()
    { 	
        for(int i = 0; i < Cases.Count;i++)
		{
            Destroy(Cases[i]);
        }
        Cases.Clear();
	}

	public void InitGrid()
	{
        DestroyGrid();
        CurrentRoom = Rooms[Random.Range(0, Rooms.Count)];
        CreatGrid(CurrentRoom);
    }

    public Vector3 GetCasePosition(int x,int y)
	{
       return grid[x,y].position;
	}

    public CaseType GetCaseType(int x, int y)
	{
        x = Mathf.Clamp(x, 0, (int)CurrentRoom.GridLenght.x - 1);
        y = Mathf.Clamp(y, 0, (int)CurrentRoom.GridLenght.y - 1);
        return grid[x, y].type;
	}

    public bool GetCaseAccesibility(int x, int y)
    {
        x = Mathf.Clamp(x, 0, (int)CurrentRoom.GridLenght.x - 1);
        y = Mathf.Clamp(y, 0, (int)CurrentRoom.GridLenght.y - 1);
        return grid[x, y].IsReachable;
    }

    public void SetCaseAccesibility(int x, int y, bool value)
    {
        x = Mathf.Clamp(x, 0, (int)CurrentRoom.GridLenght.x - 1);
        y = Mathf.Clamp(y, 0, (int)CurrentRoom.GridLenght.y - 1);
        grid[x, y].IsReachable = value;
    }

    public void SetCaseType(int x, int y, CaseType value)
    {
        grid[x, y].type = value;
    }


    public void CreatGrid(SOBJroom Room)
	{
        Vector2 GridLenght = Room.GridLenght;
        List<Vector2> victoryCase = Room.VictoryCase;
        grid = new Case[(int)GridLenght.x,(int)GridLenght.y];
        for (int i = 0; i < GridLenght.x; i++)
        {
            for (int j = 0; j < GridLenght.y; j++)
            {
                grid[i, j].position += (transform.position + ((transform.right * transformOffset) * i));
                grid[i, j].position += (transform.position + ((transform.forward * transformOffset) * j));
                grid[i, j].type = CaseType.Empty;
                grid[i, j].IsReachable = true;
                GameObject go = Instantiate(Cube,transform.position + ((transform.right * i) + transform.forward * j) -transform.up, new Quaternion());
                Cases.Add(go);
            }
        }


        for (int i = 0; i < victoryCase.Count; i++)
		{
            grid[(int)victoryCase[i].x-1, (int)victoryCase[i].y-1].type = CaseType.Exit;
        }

        for (int i = 0; i < Room.Objects.Count; i++)
        {
            factory.InstanceObject(Room.Objects[i].type, new Vector3(Room.Objects[i].position.x, -1, Room.Objects[i].position.y));
            SetCaseAccesibility((int)Room.Objects[i].position.x,(int)Room.Objects[i].position.y,false);
        }

    }

    // Update is called once per frame
    void Update()
    {
      //  DrawDebug();
    }

    public void DrawDebug()
	{
        for (int i = 0; i < (int)CurrentRoom.GridLenght.x; i++)
        {
            for (int j = 0; j < (int)CurrentRoom.GridLenght.y; j++)
            {
                Debug.DrawRay(grid[i,j].position,Vector3.up * 10);
            }
        }
     }

}
