using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public int HorizontalValue;
   public int VerticalValue;

 
    public float DesiredInputTimer;
    public Grid grid;

    public AudioSource Sound;

    public AudioClip BipSound;
    public AudioClip VictorySound;
    public TimerController timerctrl;

    public PlayerMove entity;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = grid.GetCasePosition(0,0);
    }


 
    public void CallInput()
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



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        if(GM.CanPlay)
		{
            CallInput();
		}

        
    }

 


	public void MoveCharacter(int x, int z, float rotate)
	{
        if (timerctrl.IsNearBeat())
        {
            GM.AddMultiplicator();
            GM.AddScore();
            Sound.PlayOneShot(VictorySound);
            entity.MoveCharacter(x, z, rotate);
         
        }
        else
		{
            GM.RestMultiplicator();
		}
     
    }



}
