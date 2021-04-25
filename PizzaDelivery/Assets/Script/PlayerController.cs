using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public int HorizontalValue;
   public int VerticalValue;

    float InputTimer;
    public float DesiredInputTimer;
    bool CanMove = false;
    public Grid grid;

    public AudioSource Sound;

    public AudioClip BipSound;
    public AudioClip VictorySound;
    public TimerController timerctrl;

    public PlayerMove entity;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = grid.GetCasePosition(0,0);
        timerctrl.onBeat += SetInputTimer;
        CanMove = true;
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

        

        if(Input.GetKeyDown(KeyCode.Escape))
		{
            Application.Quit();
		}


        if(InputTimer > 0)
		{
            InputTimer -= Time.deltaTime;
		}
    }

 


	public void MoveCharacter(int x, int z, float rotate)
	{
        if (timerctrl.IsNearBeat())
        {
            Sound.PlayOneShot(VictorySound);
            entity.MoveCharacter(x, z, rotate);
         
        }
     
    }



}
