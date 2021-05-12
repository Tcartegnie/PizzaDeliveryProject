using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Objectlist", menuName = "ScriptableObjects/Objectlist", order = 3)]
public class SOBJObjectList : ScriptableObject
{
	public List<SOBJObject> objects = new List<SOBJObject>();

	public GameObject GetObjByType(TypeCrate type)
	{
		return objects.Find(obj => obj.objtype == type).obj;
	}

}