using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image image;

    public void ShowPicture()
	{
		image.enabled = true;
	}

	public void HidePicture()
	{
		image.enabled = false;
	}

	
}
