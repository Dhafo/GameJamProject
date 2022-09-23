using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using TMPro;

public class FadeText : MonoBehaviour
{

    public TextMeshProUGUI text;
    public float fadeSpeed;

    public void RunFade()
    {
        StartCoroutine(FaderText(true));
    }

    IEnumerator FaderText(bool fadeAway)
    {

        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, i);
                yield return null;
            }
        }
    }
}
