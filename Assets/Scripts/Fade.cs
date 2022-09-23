using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;

public class Fade : MonoBehaviour
{

    public Image img;
    public float fadeSpeed;

    public bool faded = false;

    public void RunFade(bool away) 
    {
        StartCoroutine(FadeImage(away));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
        }
    }
}
