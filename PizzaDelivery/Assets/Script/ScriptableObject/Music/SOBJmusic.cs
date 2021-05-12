using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/Music", order = 2)]

public class SOBJmusic : ScriptableObject
{
	public AudioClip clip;
	public int BPM;
	public float BeatMargin;
}
