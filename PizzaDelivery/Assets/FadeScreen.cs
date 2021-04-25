using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{

	public Image ScreenRect;
	public Text Victorytext;
	public float FadeDuration;

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


	public IEnumerator fade()
	{
		ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b, 0);
		Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b, 0);
		for (float i = 0; i < 1;i+= Time.deltaTime/ FadeDuration) 
		{
			ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b, i);
			Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b, i);
			yield return null;
		}
		ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b,1);
		Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b,1);
	}


	public IEnumerator UnFade()
	{
		ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b, 1);
		Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b, 1);
		for (float i = 1; i > 0; i -= Time.deltaTime / FadeDuration)
		{
			ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b, i);
			Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b, i);
			yield return null;
		}
		ScreenRect.color = new Color(ScreenRect.color.r, ScreenRect.color.g, ScreenRect.color.b, 0);
		Victorytext.color = new Color(Victorytext.color.r, Victorytext.color.g, Victorytext.color.b, 0);
	}
}
