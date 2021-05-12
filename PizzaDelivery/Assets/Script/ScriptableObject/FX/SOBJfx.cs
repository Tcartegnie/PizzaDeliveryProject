using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/FX/FX", order = 2)]
public class SOBJfx : ScriptableObject
{
	public string fxNAME;
	public GameObject FXPrefab;
}
