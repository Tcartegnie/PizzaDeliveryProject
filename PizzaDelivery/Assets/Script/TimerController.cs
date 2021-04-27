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

    public delegate void Beat();

    public Beat onBeat;
    public GameManager GM;
    public RectTransform Startrect;

    public BeatDisplay beatDisplay;

    public RectTransform BluePicture;

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
       // beatDisplay.InstantiateBeat();
    }

    public float GetSecPerBeat()
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

        if (GM.CanPlay && GameStart)
        {
            ComputeMusicPosition(); 
            Metronome();
        }

        if(IsNearBeat())
		{
            BluePicture.gameObject.SetActive(true);
        }
        else
		{
            BluePicture.gameObject.SetActive(false);
        }
    }


    public void Metronome()
	{       
            (CurrentBeatTimer) -= Time.deltaTime;
            if (CurrentBeatTimer <= 0f)
            {
                IsBeating();
                //Vu que CurrentBeatTimer n'est jamais pile à zéro on perd des millisecondes si on remet à GetSecPerBeat, du coup, je rajoute SecPerBeat pour équilibrer. C'est pas un souci
                CurrentBeatTimer += SecPerBeat;
            }
    }

    public bool IsNearBeat()
    {
        //Bon j'ai fait des tests et en vrai on a envie de se dire "ouais l'user blabla il appuie toujours après" mais en vrai j'ai l'impression qu'on anticipe plus qu'autre chose, du coup j'ai mis ça et ça marche beaucoup mieux je trouve, ça 
             return CurrentBeatTimer > GetSecPerBeat() - BeatMargin;
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
