using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDisplay : MonoBehaviour
{
    public RectTransform BeatRect;

    public List<RectTransform> Rects = new List<RectTransform>();
    public List<GameObject> Lines = new List<GameObject>();
    public GameObject BeatLine;


    public TimerController controller;
    public float spb;
    public bool IsStarted = false;
    public int LineNumber;

    bool PlayMusic;
    // Start is called before the first frame update


    public void TurnOnUI()
	{
        gameObject.SetActive(true);
	}

    public void TurnOffUI()
	{
        gameObject.SetActive(false);
    }

   public void StartMusic()
	{
        spb = controller.GetBeatTime();
        ClearList();
        InstantiateBeats();
        PlayMusic = true;
    }


    public void InstantiateBeats()
	{
        for (int i = 0; i < LineNumber; i++)
        {
            InstantiateBeat(i);
        }
    }

	public void Update()
	{
		if(PlayMusic)
		{
            foreach (GameObject GO in Lines)
			{
                GO.GetComponent<BeatObject>().Move(spb);
			}
        }
	}

    public void SetObjectOnLine()
	{
        for (int i = 0; i < Lines.Count;i++)
		{
            for (int j = 0; j < Rects.Count; j++)
            {
                Lines[i].GetComponent<BeatObject>().SetPositionOnLine((1f/LineNumber) * i);
            }
        }
	}

	public void InstantiateBeat(int CurrentLine)
	{
		for (int i = 0; i < Rects.Count; i++)
		{
			GameObject GO = Instantiate(BeatLine, Rects[i]);
            GO.GetComponent<BeatObject>().Init(Rects[i].position, BeatRect.position, (1f / LineNumber) * CurrentLine) ;
            Lines.Add(GO);
		}
	} 


    public void ClearList()
	{
        for(int i  = 0; i < Lines.Count;i++)
		{
            Destroy(Lines[i]);
		}
        Lines.Clear();
	}
}
