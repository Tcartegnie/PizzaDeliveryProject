using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public FadeScreen screen;
	public string VictroryText;
	public string TrueVictroryText;
	public string DefeatText;
	public delegate void OnEndGame();
	public OnEndGame onVictory;
	public OnEndGame onDefeat;
	public Grid grid;
	public TimerController ctrl;

	public MovingEntity Player;
	public MovingEntity Alien;

	public RectTransform StartRect;
	int VictoryRoom = 0;

	public void Start()
	{
		FloorCount =0;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			SceneManager.LoadScene(0);
		}
	}

	int FloorCount;

	public bool CanPlay = true;
	public void Victory()
	{
		VictoryRoom++;
		if (VictoryRoom == 4)
		{
			screen.SetText(VictroryText);
			StartCoroutine(TransitionScene());
			VictoryRoom = 0;
			FloorCount++;
			onVictory();
		}
		else
		{
			onVictory();
		}


		if (FloorCount < 15)
		{
			CanPlay = false;
			EndGame();
		}
		else
		{
			TrueEnd();
		}

	}
	public void Defeat()
	{
		screen.SetText(DefeatText);
		onDefeat();
		EndGame();
		StartCoroutine(TransitionScene());
		VictoryRoom = 0;
	}

	public void TrueEnd()
	{
		screen.SetText(TrueVictroryText);
		StartCoroutine(screen.fade());
	}

	public void EndGame()
	{
		CanPlay = false;
	}

	public void StartGame()
	{
		CanPlay = true;
	
	}


	public void InitGame()
	{
		Alien.gameObject.SetActive(true);
		Alien.InitEntity();
		Player.gameObject.SetActive(true);
		Player.InitEntity();
		StartRect.gameObject.SetActive(true);
	}
	IEnumerator TransitionScene()
	{
		yield return StartCoroutine(screen.fade());
		grid.InitGrid(0);
		yield return null;
		InitGame();
		yield return StartCoroutine(screen.UnFade());
		StartGame();
	}

}
