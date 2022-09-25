using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Fade fade;
    public int scene;

    public void OnPlay() 
    {
        StartCoroutine(OnPress());
    }
    IEnumerator OnPress() 
    {
        fade.RunFade(false);
        if(Time.timeScale == 0) 
        {
            Time.timeScale = 1;
            yield return new WaitForSeconds(.8f);
        }
        else 
        {
            yield return new WaitForSeconds(1.3f);
        }
        PlayerPrefs.SetInt("showCutscene", 1);
        SceneManager.LoadScene(scene);
    }
}
