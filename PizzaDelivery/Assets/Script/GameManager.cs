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
	public int RoomPerFloor;
	public int FloorMax;
	public delegate void OnEndGame();
	public OnEndGame onVictory;
	public OnEndGame onDefeat;
	public Grid grid;
	public TimerController ctrl;

	public MovingEntity Player;
	public ScoreDisplayer scoreDisplayer;
	public RectTransform StartRect;
	public int VictoryRoom = 0;

	public int score = 0;
	public int Multiplicator = 1;
	public int ScorePerBeat;
	public int MultiplicatorCount = 0;
	public int FloorCount;
	public void Start()
	{
		FloorCount =0;
		score = 0;
		Multiplicator = 1;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			SceneManager.LoadScene(0);
		}
	}



	public void AddScore()
	{
		AddScore(ScorePerBeat);
	}


	public void AddScore(int value)
	{
		score += value * Multiplicator;
		scoreDisplayer.SetScore(score);
	}

	public void KillEnnemy(int value)
	{
		Multiplicator += 1;
		AddScore(value);
	}

	public void AddMultiplicator()
	{
		MultiplicatorCount++;
		if(MultiplicatorCount >= 3)
		{
			Multiplicator += 1;
			scoreDisplayer.SetMultiplicator(Multiplicator);
		}
	}



	public void RestMultiplicator()
	{
		MultiplicatorCount = 0;
		Multiplicator = 1;
		scoreDisplayer.SetMultiplicator(Multiplicator);
	}

	public bool CanPlay = true;
	public void Victory()
	{
		if (VictoryRoom == RoomPerFloor)
		{
			screen.SetText(VictroryText);
			StartCoroutine(TransitionScene());
			VictoryRoom = 0;
			FloorCount++;
			onVictory();
		}
		else
		{
			VictoryRoom++;
			onVictory();
		}


		if (FloorCount == FloorMax)
		{
			CanPlay = false;
			EndGame();
			scoreDisplayer.DisplayFinalScore();
			TrueEnd();
		}
		scoreDisplayer.SetFloorCount(FloorCount);
		scoreDisplayer.SetRoomCount(VictoryRoom);
	}
	public void Defeat()
	{
		screen.SetText(DefeatText);
		onDefeat();
		EndGame();
		StartCoroutine(TransitionScene());
		VictoryRoom = 0;
		scoreDisplayer.SetRoomCount(VictoryRoom);
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
		Player.InitEntity();
		StartRect.gameObject.SetActive(true);
	}
	IEnumerator TransitionScene()
	{
		yield return StartCoroutine(screen.fade());
		grid.InitGrid(0);
		yield return StartCoroutine(screen.UnFade());
		StartGame();
	}

}
