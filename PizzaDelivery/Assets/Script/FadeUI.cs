using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    public float FadeDuration;
    public IEnumerator fadeIn(Image picture)
	{
        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0);
        for (float i = 0; i < 1; i += Time.deltaTime / FadeDuration)
        {
            picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, i);
            yield return null;
        }

        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 1);
    }

    public IEnumerator fadeIn(Text Text)
    {
        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 0);
        for (float i = 0; i < 1; i += Time.deltaTime / FadeDuration)
        {
            Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, i);
            yield return null;
        }

        Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, 1);
    }

    public IEnumerator fadeOut(Image picture)
    {
        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b,1);
        for (float i = 1; i > 0; i -= Time.deltaTime / FadeDuration)
        {
            picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, i);
            yield return null;
        }

        picture.color = new Color(picture.color.r, picture.color.g, picture.color.b, 0);
    }

    public IEnumerator fadeOut(Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        for (float i = 1; i > 0; i -= Time.deltaTime / FadeDuration)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, i);
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

}
