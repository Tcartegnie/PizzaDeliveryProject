using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public int HorizontalValue;
   public int VerticalValue;

    int CurrentXPosition;
    int CurrentZPosition;

    float InputTimer;
    public float DesiredInputTimer;
    public Grid grid;

    public AudioSource Sound;

    public AudioClip BipSound;
    public AudioClip VictorySound;
    public TimerController timerctrl;

    public MovingEntity entity;

    // Start is called before the first frame update
    void Start()
    {
        grid.InitGrid();
        transform.position = grid.GetCasePosition(0,0);
        timerctrl.onBeat += SetInputTimer;
    }

    public void SetInputTimer()
	{
        InputTimer = DesiredInputTimer;

    }
 

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveCharacter(-1, 0, -90);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveCharacter(1, 0, 90);
            }


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveCharacter(0, 1, 0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveCharacter(0, -1, 180);
            }
            
            if(Input.GetKeyDown(KeyCode.Space))
    		{
                
    		}

        if(InputTimer > 0)
		{
            InputTimer -= Time.deltaTime;
		}
    }

    public void Attack()
	{

	}

	public void Move(int x, int z)
	{
        entity.AddPosition(x, z);
        entity.ClampPosition();
        transform.position = grid.GetCasePosition(CurrentXPosition, CurrentZPosition);
    }

	public void MoveCharacter(int x, int z, float rotate)
	{
        if (InputTimer > 0)
        {
            Sound.PlayOneShot(VictorySound);
        }
        entity.Move(x, z);
        entity.RotatePerso(rotate);
    }


}
