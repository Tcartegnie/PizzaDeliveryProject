using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public SOBJObjectList list;
	public Grid grid;
	public TimerController time;
	public GameManager GM;
	public GameObject Ennemy;
	public Transform Target;
	List<GameObject> obj;
	
   public GameObject InstanceObject(TypeCrate type, Vector3 position)
	{
		GameObject GO = list.GetObjByType(type);
		GO = Instantiate(GO, position, new Quaternion());
		return GO; 
	}

	public GameObject InstanceObject(GameObject OBJ,Vector3 position)
	{
		GameObject	GO = Instantiate(OBJ, position, new Quaternion());
		return GO;
	}


	public GameObject InstanceObject(TypeCrate type, Vector3 position, Transform parent)
	{
		GameObject GO = InstanceObject(type, position);
		GO.transform.SetParent(parent, false);
		return GO;
	}

	public GameObject InstanceObject(GameObject obj,Vector3 position, Transform parent)
	{
		GameObject GO = InstanceObject(obj, position);
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

	public GameObject InstanciateEnnemy(Vector3 position,Transform parent)
	{
		
		GameObject GO = InstanceObject(Ennemy, position, parent);
		GO.GetComponent<EntityState>().Init(grid,GM);
		GO.GetComponent<AlienMove>().Init(position, grid, GM, time, Target);
		GO.GetComponent<AlienAttack>().Init(time,grid,Target);
		Vector3 test = grid.GetCasePosition((int)position.x, (int)position.z);
		GO.transform.position = new Vector3(test.x,0,test.z);
		return GO;
	}

}
