using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
	public Text score;
	public Text Multiplicator;
	public Text FloorCount;
	public Text RoomCount;
	public GameManager GM;

	public Text TextFinalScore;
	public Text TextCongratulation;
	public Image Background;
	public float TextFadeDuration;

	public void Start()
	{
		SetScore(GM.score);
		SetMultiplicator(GM.Multiplicator);
		SetFloorCount(GM.FloorCount);
		SetRoomCount(GM.VictoryRoom);

	}

	public void DisplayFinalScore()
	{
		SetFinalScore(GM.score);
		StartCoroutine(FinalDisplay());
	}

	public void SetScore(int scoreValue)
	{
		score.text = "Score : " + scoreValue.ToString();
	}

	public void SetMultiplicator(int multiplicatorValue)
	{
		Multiplicator.text = "Multiplicator : " + multiplicatorValue.ToString() + "x";
	}

	public void SetFloorCount(int FloorCountValue)
	{
		FloorCount.text = "Floor : " + FloorCountValue.ToString()+"/" + GM.FloorMax;
	}

	public void SetRoomCount(int RoomCountValue)
	{
		RoomCount.text = "Room : " + RoomCountValue.ToString() + "/" + GM.RoomPerFloor;
	}

	public void SetFinalScore(int FinalScore)
	{
		TextFinalScore.text = "Final score  : " + FinalScore.ToString() + "!";
	}

	public IEnumerator FinalDisplay()
	{
		yield return StartCoroutine(DisplayFinalScore(Background));
		yield return StartCoroutine(DisplayFinalScore(TextFinalScore));
		yield return StartCoroutine(DisplayFinalScore(TextCongratulation));
	}
	public IEnumerator DisplayFinalScore(Text text)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
		for (float i = 0; i < 0; i += Time.deltaTime / TextFadeDuration)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, i);

			yield return null;
		}
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
	}


	public IEnumerator DisplayFinalScore(Image Pic)
	{
		Pic.color = new Color(Pic.color.r, Pic.color.g, Pic.color.b, 0);
		for (float i = 0; i < 0; i += Time.deltaTime / TextFadeDuration)
		{
			Pic.color = new Color(Pic.color.r, Pic.color.g, Pic.color.b, i);

			yield return null;
		}
		Pic.color = new Color(Pic.color.r, Pic.color.g, Pic.color.b, 1);
	}

}
