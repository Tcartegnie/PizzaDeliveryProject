using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    public float songposition;
    public float songpositioninBeats;
    public int LastsongpositioninBeats;
    public float OffBeatOffset;
    public float CurrentBeat;

    public float dspsongTime;
    public float InputCoolDown;

    public float SecPerBeat;
    public float SongBPM;
    public AudioSource Music;

    public delegate void Beat();

    public Beat onBeat;
  

    public float GetPositonInSong()
    {
        return (float)(AudioSettings.dspTime - dspsongTime - OffBeatOffset);
    }
    public float GetPositionInBeat()
    {
        return songposition / SecPerBeat;
    }

    public void IsBeating()
	{
        onBeat();
    }

    // Start is called before the first frame update
    void Start()
    {
        SecPerBeat = 60f / SongBPM;
        dspsongTime = (float)AudioSettings.dspTime;
        Music.Play();
    }

    private void FixedUpdate()
    {

        songposition = GetPositonInSong();
        songpositioninBeats = GetPositionInBeat();

        CurrentBeat += Time.deltaTime;
        if(CurrentBeat >= SecPerBeat)
		{
            IsBeating();
            CurrentBeat = 0;
		}


        LastsongpositioninBeats = (int)songpositioninBeats;
    }

}
