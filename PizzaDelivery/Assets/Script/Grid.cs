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
    public List<GameObject> ObjectOnFloor = new List<GameObject>();
    public SOBJroom VisoRoom;
    Case[,] grid;
    public Vector2 VictoryGrid;
    public bool Visibility;
    public float TransitionDuration;
    public Factory factory;

    Transform currentTransform;
    public PlayerMove player;
    public GameManager gm;
    public Vector2 GetGridLenght()
	{
        return new Vector2((int)CurrentRoom.GridLenght.x,(int)CurrentRoom.GridLenght.y);
	}

	public void Awake()
	{
        if (!Visibility)
        {
            InitGrid(0);
        }
        else
		{
            LoadTestRoom();
        }
	}

    void LoadTestRoom()
	{
        CurrentRoom = VisoRoom;
        DestroyGrid();
        CreatGrid(CurrentRoom, 0);
    }

	public void Start()
	{
        gm.onVictory += OnVictory;

    }

    public void OnVictory()
	{
        StartCoroutine(RoomTransition());
	}

	public void DestroyGrid()
    { 	
        for(int i = 0; i < ObjectOnFloor.Count;i++)
		{
            Destroy(ObjectOnFloor[i]);
        }
        ObjectOnFloor.Clear();
	}

	public void InitGrid(int BeginOffset)
	{
        DestroyGrid();
        CurrentRoom = Rooms[Random.Range(0, Rooms.Count)];
        CreatGrid(CurrentRoom, BeginOffset);
    
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


    public void CreatGrid(SOBJroom Room, int BeginOffset)
	{
        currentTransform = Instantiate( new GameObject(),transform,true).transform;
        player.transform.SetParent(currentTransform);
 
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
                GameObject go = Instantiate(Cube,transform.position + ((transform.right * i) + transform.forward * j) -transform.up, new Quaternion(),currentTransform);
                ObjectOnFloor.Add(go);
            }
        }
        player.SetCharacterPositionData(Room.StartCase.x, Room.StartCase.y);
        player.SetCharacterPosition();
        player.InitEntity();
        player.GetComponent<StatePlayer>().InitLife();
        for (int i = 0; i < victoryCase.Count; i++)
		{
            grid[(int)victoryCase[i].x-1, (int)victoryCase[i].y-1].type = CaseType.Exit;
        }

        for (int i = 0; i < Room.Objects.Count; i++)
        {
            GameObject GO = factory.InstanceObject(TypeCrate.Baril, new Vector3(Room.Objects[i].position.x, -1, Room.Objects[i].position.y),currentTransform);
            SetCaseAccesibility((int)Room.Objects[i].position.x,(int)Room.Objects[i].position.y,false);
            ObjectOnFloor.Add(GO);
        }

        for (int i = 0; i < Room.Enemies.Count; i++)
        {
            GameObject GO = factory.InstanciateEnnemy(new Vector3(Room.Enemies[i].x, -1, Room.Enemies[i].y),currentTransform);
            
            SetCaseAccesibility((int)Room.Enemies[i].x, (int)Room.Enemies[i].y, false);
            ObjectOnFloor.Add(GO);
        }
        currentTransform.position = currentTransform.position + transform.forward * BeginOffset;
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

    public IEnumerator RoomTransition()
	{
        Transform removingtranform = currentTransform;
        for (float i = 0; i < 1; i += Time.deltaTime /(TransitionDuration/2))
		{
            Vector3 Depart = removingtranform.position;
            Vector3 Arrival = removingtranform.position - transform.forward * 100;
            removingtranform.position = Vector3.Lerp(Depart, Arrival, i);
            yield return null;
		}
        InitGrid(100);
       
        for (float i = 0; i < 1; i += Time.deltaTime / (TransitionDuration/2))
        {
            Vector3 Depart = currentTransform.position;
            Vector3 Arrival = Vector3.zero;
            currentTransform.position = Vector3.Lerp(Depart, Arrival, i);
            yield return null;
        }
        gm.StartGame();
    }

    public void removeEntity(GameObject GO)
	{
        ObjectOnFloor.Remove(GO);

    }

}
