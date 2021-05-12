using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatObject : MonoBehaviour
{
	public float Direction = 1;
	public float Tempo;
	public RectTransform rect;
	Vector3 destination;
	Vector3 starts;
	float CurrentRatio;
	public void Init(Vector3 Start, Vector3 Destination,float CurrentPosition)
	{
		starts = Start;
		destination = Destination;
		CurrentRatio = CurrentPosition;
		SetPositionOnLine(CurrentRatio);
	}

	public void SetTempo(float tempo)
	{
		Tempo = tempo;
	}

	public void Move(float GetBeatTime)
	{
		if (CurrentRatio < 1)
		{
			CurrentRatio += Time.deltaTime * GetBeatTime;
			for (int i = 0; i < 2; i++)
			{
				SetPositionOnLine(CurrentRatio);
			}
		}
		else
		{
			CurrentRatio = 0;
		}
	}

	public void SetPositionOnLine(float CurrentRatio)
	{
		transform.position = Vector3.Lerp(new Vector3(starts.x, 0, 0), new Vector3(destination.x, 0, 0), CurrentRatio);
	}

}
