using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{

    public float songposition;
    public float songpositioninBeats;
    public float OffBeatOffset;
    public float CurrentBeatTimer;

    public float dspsongTime;
    public float InputCoolDown;

    public float SecPerBeat;
    public float SongBPM;
    public float BeatMargin;
    public AudioSource Music;

    public SOBJMusicList MusicList;

    public delegate void Beat();

    public Beat onBeat;
    public GameManager GM;
    public RectTransform Startrect;

    public BeatDisplay beatDisplay;

    public RectTransform BluePicture;

    public bool GameStart = false;


    public BeatDisplay beatDisplayer;
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
        if (onBeat != null)
        {
            onBeat();
        }
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
        SecPerBeat = GetSecPerBeat();
        dspsongTime = (float)AudioSettings.dspTime;
        songposition = 0;
        songpositioninBeats = 0;
        InputCoolDown = 0;
        GameStart = true;
        Music.Play();
        beatDisplay.StartMusic();
    }

    public void SetMusic(SOBJmusic music)
	{
        StopMusic();
        SongBPM = music.BPM;
        BeatMargin = music.BeatMargin;
        Music.clip = music.clip;
        StartMusic();
    }

    public void PauseMusic()
	{
        Music.Pause();
        GameStart = false;
    }

    public void ContinueMusic()
	{
        Music.UnPause();
        GameStart = true;
    }

    public void StopMusic()
	{
        Music.Stop();
        GameStart = false;
    }

    public void ChangeMusic()
	{

	}

    public float GetSecPerBeat()
	{
      return 60f /SongBPM ;
    }

	private void Update()
	{
		if(!GameStart)
		{
            if(Input.anyKeyDown)
			{
                Startrect.gameObject.SetActive(false);
                SetMusic(MusicList.GetRandomSound());
                beatDisplay.StartMusic();
            }
		}

        if (GM.CanPlay && GameStart)
        {
            ComputeMusicPosition(); 
            Metronome();
        }
    }


    public void Metronome()
	{       
            (CurrentBeatTimer) -= Time.deltaTime;
            if (CurrentBeatTimer <= 0f)
            {
                IsBeating();
                CurrentBeatTimer += SecPerBeat;
            }
    }

    public bool IsNearBeat()
    {
      return CurrentBeatTimer > GetBeatTime();
    }

    public float GetBeatTime()
	{
      return   GetSecPerBeat() - BeatMargin;
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
