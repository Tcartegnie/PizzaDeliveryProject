using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDisplay : MonoBehaviour
{
    public RectTransform BeatRect;

    public List<RectTransform> Rects;
    public GameObject BeatLine;


    public TimerController controller;
    public float spb;
    public bool IsStarted = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

   
 

    public void OnBeat()
	{
        //InstantiateBeat();
	}

    public void InstantiateBeat()
	{
       
            controller.onBeat += OnBeat;
            spb = controller.GetBeatPerSecond();
            for (int i = 0; i < 2; i++)
            {
                GameObject GO = Instantiate(BeatLine, Rects[i]);
                GO.GetComponent<RectTransform>().pivot.Set(0.5f, 0);
                GO.GetComponent<RectTransform>().rect.Set(0, 0, 0, 0);
                StartCoroutine(MoveLine(GO.transform, Rects[i], BeatRect));
            }
      
    }

    IEnumerator MoveLine(Transform GO,Transform Line,Transform destination)
	{
        Vector3 depart = Line.position;
        Vector3 Arrival = destination.position;
        for(float i = 0; i < 1; i+= Time.deltaTime/spb)
		{
            GO.position = Vector3.Lerp(new Vector3(depart.x,0,0),new Vector3(Arrival.x,0,0),i);
            yield return null;
		}
        GO.position = Vector3.Lerp(new Vector3(depart.x, 0, 0), new Vector3(Arrival.x, 0, 0), 1);
      StartCoroutine(MoveLine(GO,Line,destination));
    }
}
