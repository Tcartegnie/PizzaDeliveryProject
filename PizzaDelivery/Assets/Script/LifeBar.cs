using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
	public GameObject LifeRect;
	public List<GameObject> LifePictures = new List<GameObject>() ;
	public int CurrentLife = 0;


	public void ClearLifeList()
	{
		for(int i = 0; i < LifePictures.Count;i++)
		{
			Destroy(LifePictures[i]);
		}
		LifePictures.Clear();
	}

	public void Init(int Life)
	{
		CurrentLife = Life;
		for(int i = 0; i < CurrentLife;i++)
		{
			AddNewLifeCase();
		}
		UpdateLife(Life);
	}
	public void ClampLifeQuantity()
	{
		CurrentLife = Mathf.Clamp(CurrentLife,0,LifePictures.Count-1);
	}

	public void UpdateLife(int currentLife)
	{
		for (int i = 0; i < LifePictures.Count; i++)
		{
			LifePictures[i].GetComponent<LifeUI>().HidePicture();
		}
		for (int i = 0; i < currentLife; i++)
		{
			LifePictures[i].GetComponent<LifeUI>().ShowPicture();
		}
	}



	public void AddNewLifeCase()
	{
		if(LifePictures.Count < CurrentLife)
		LifePictures.Add(Instantiate(LifeRect,transform));
	}



}
