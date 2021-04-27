using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/Object", order = 2)]
public class SOBJObject : ScriptableObject
{
	public TypeCrate objtype;
	public GameObject obj;
}
