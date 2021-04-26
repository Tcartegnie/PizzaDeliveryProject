using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum TypeCrate
{
	Baril,
}

[Serializable]
public struct GridOBJ
{
	public TypeCrate type;
	public Vector2 position;
}

[Serializable]
[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Room", order = 1)]
public class SOBJroom : ScriptableObject
{
	public Vector2 GridLenght;
	public List<Vector2> VictoryCase;
	public List<GameObject> LeftWall = new List<GameObject>();
	public List<GameObject> FrontWall = new List<GameObject>();
	public List<GridOBJ> Objects = new List<GridOBJ>();
	public List<Vector2> Enemies = new List<Vector2>();
}

[Serializable]
[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/Object", order = 2)]
public class SOBJObject : ScriptableObject
{
	public TypeCrate objtype;
	public GameObject obj;
}

[Serializable]
[CreateAssetMenu(fileName = "Objectlist", menuName = "ScriptableObjects/Objectlist", order = 3)]
public class SOBJObjectList : ScriptableObject
{
	public List<SOBJObject> objects = new List<SOBJObject>();

	public GameObject GetObjByType(TypeCrate type)
	{
	 return	objects.Find(obj => obj.objtype == type).obj;
	}

}