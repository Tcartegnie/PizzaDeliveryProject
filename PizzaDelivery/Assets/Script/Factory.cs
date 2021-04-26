using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public SOBJObjectList list;
	List<GameObject> obj;
   public GameObject InstanceObject(TypeCrate type, Vector3 position)
	{
		GameObject GO = list.GetObjByType(type);
		GO = Instantiate(GO, position, new Quaternion());
		return GO; 
	}

	public GameObject InstanceObject(TypeCrate type, Vector3 position, Transform parent)
	{
		GameObject GO = InstanceObject(type, position);
		GO.transform.SetParent(parent, false);
		return GO;
	}

	public void ClearOBJ()
	{
		for(int i = 0; i < obj.Count; i++)
		{
			GameObject GO = obj[i];
			obj.Remove(GO);
		}
		obj.Clear();
	}
}
