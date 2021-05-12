using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

	public Image ScreenRect;
	public Text Victorytext;
	public FadeUI fade;

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			SetText("Test");
		}
	}
	public void SetText(string text)
	{
		Victorytext.text = text;
	}


	public IEnumerator fadeIn()
	{
		StartCoroutine(fade.fadeIn(ScreenRect));
		yield return StartCoroutine(fade.fadeIn(Victorytext));
	}


	public IEnumerator FadeOut()
	{
		StartCoroutine(fade.fadeOut(ScreenRect));
		yield return StartCoroutine(fade.fadeOut(Victorytext));
	}
}
