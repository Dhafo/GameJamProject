using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Fade fade;

    public void OnPlay() 
    {
        StartCoroutine(OnPress());
    }
    IEnumerator OnPress() 
    {
        fade.RunFade(false);
        yield return new WaitForSeconds(.76f);
        PlayerPrefs.SetInt("showCutscene", 1);
        SceneManager.LoadScene(1);
    }
}
