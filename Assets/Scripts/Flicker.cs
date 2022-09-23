using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Flicker : MonoBehaviour
{
    public GameManager manager;
    public TextMeshPro img;
    public float fadeSpeed;

    public bool faded = false;

    public void Start()
    {
        StartCoroutine(FadeImage());
    }

    public void Update()
    {
        if (manager.hasStarted)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FadeImage()
    {

        if (faded == false)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
            faded = true;
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
            faded = false;
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(FadeImage());

    }
}

