using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "MusicList", menuName = "ScriptableObjects/MusicList", order = 2)]
public class SOBJMusicList : ScriptableObject
{
	public List<SOBJmusic> musics;
	public SOBJmusic GetRandomSound()
	{
		return musics[UnityEngine.Random.Range(0, musics.Count)];
	}
}
