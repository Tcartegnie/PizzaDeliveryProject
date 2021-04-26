using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public FadeScreen screen;
	public string VictroryText;
	public string DefeatText;
	public delegate void OnEndGame();
	public OnEndGame onVictory;
	public OnEndGame onDefeat;
	public Grid grid;
	public TimerController ctrl;

	public MovingEntity Player;
	public MovingEntity Alien;

	public RectTransform StartRect;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			SceneManager.LoadScene(0);
		}
	}

	public bool CanPlay = true;
	public void Victory()
	{
		screen.SetText(VictroryText);
		onVictory();
		CanPlay = false;
		EndGame();
		StartCoroutine(TransitionScene());
		
	}

	public void Defeat()
	{
		screen.SetText(DefeatText);
		onDefeat();
		EndGame();
		StartCoroutine(TransitionScene());
	
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
		yield return StartCoroutine( screen.fade());
		grid.InitGrid();
		yield return null;
		InitGame();
		yield return StartCoroutine(screen.UnFade());
		StartGame();
	}

}
