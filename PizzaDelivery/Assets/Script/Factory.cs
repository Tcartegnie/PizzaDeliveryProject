using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public SOBJObjectList list;
	List<GameObject> obj;
   public void InstanceObject(TypeCrate type, Vector3 position)
	{
		GameObject GO = list.GetObjByType(type);
		Instantiate(GO, position, new Quaternion());
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
