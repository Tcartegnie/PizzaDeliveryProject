using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Room", order = 1)]
public class SOBJroom : ScriptableObject
{
	public Vector2 GridLenght;
	public List<Vector2> VictoryCase;
	public List<GameObject> LeftWall = new List<GameObject>();
	public List<GameObject> FrontWall = new List<GameObject>();
}
