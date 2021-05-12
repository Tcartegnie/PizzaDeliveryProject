using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Music", menuName = "ScriptableObjects/FX/FX list", order = 2)]
public class SOBJfxList : ScriptableObject
{
	public List<SOBJfx> FXs = new List<SOBJfx>();

	public GameObject GetFXByName(string FXname)
	{
		return FXs.Find(fx => fx.fxNAME == FXname).FXPrefab;
	}
}
