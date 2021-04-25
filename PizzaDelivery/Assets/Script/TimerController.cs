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
    public GameManager GM;
    public RectTransform Startrect;

    public BeatDisplay beatDisplay;

    public bool GameStart = false;
    public float GetPositonInSong()
    {
        return (float)(AudioSettings.dspTime - dspsongTime - (OffBeatOffset));
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
        GM.onVictory += OnEndGame;
        GM.onDefeat += OnEndGame;
      //  onBeat += beatDisplay.OnBeat;
    }

    public void StartMusic()
	{
        SecPerBeat = GetBeatPerSecond();
        dspsongTime = (float)AudioSettings.dspTime;
        songposition = 0;
        songpositioninBeats = 0;
        InputCoolDown = 0;
        GameStart = true;
        Music.Play();
        beatDisplay.InstantiateBeat();
    }

    public float GetBeatPerSecond()
	{
      return 60f / SongBPM;
    }

	private void Update()
	{
		if(!GameStart)
		{
            if(Input.anyKeyDown)
			{
                Startrect.gameObject.SetActive(false);
                StartMusic();
            }
		}
    }




    private void FixedUpdate()
    {
        if (GM.CanPlay && GameStart)
        {
            ComputeMusicPosition();
            if (songposition > OffBeatOffset)
            {
                Metronome();
            }
        }
    }

    public void Metronome()
	{       
            (CurrentBeat) += Time.deltaTime;
            if (CurrentBeat >= SecPerBeat)
            {
                IsBeating();
                CurrentBeat = 0;
            }
            LastsongpositioninBeats = (int)songpositioninBeats;
    }

    void ComputeMusicPosition()
	{
        songposition = GetPositonInSong();
        songpositioninBeats = GetPositionInBeat();
    }

    void OnEndGame()
	{
        GameStart = false;
        Music.Stop();
    }

}
