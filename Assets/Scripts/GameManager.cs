using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public bool hasStarted = false;

    public Fade FadeIn;

    public float fadeTime1;
    public Fade CutSceneBackground;
    public float fadeTime2;
    public FadeText text1;

    public PlayableDirector director;
    public float fadeTime3;
    public CinemachineVirtualCamera cam;

    public float fadeTime4;
    public Fade CutSceneBackground2;
    public float fadeTime5;
    public FadeText text2;

    public Canvas canvas;


  

    private void Start()
    {
        if (PlayerPrefs.GetInt("showCutscene") == 1)
        {
            StartCoroutine(StartCutscene());
            PlayerPrefs.SetInt("showCutscene", 0);
        }
        else 
        {
            canvas.gameObject.SetActive(false);
            cam.gameObject.SetActive(false);
            //director.Play();
            //cam.Priority = 0;
            StartGame();
        }

    }
    public void StartGame() 
    { 
        hasStarted = true;
    }

    IEnumerator StartCutscene() 
    {
        yield return new WaitForSeconds(1f);
        FadeIn.RunFade(true);
        yield return new WaitForSeconds(fadeTime1);
        text1.RunFade();
        yield return new WaitForSeconds(fadeTime2);
        CutSceneBackground.RunFade(true);
        yield return new WaitForSeconds(fadeTime4);
        text2.RunFade();
        yield return new WaitForSeconds(fadeTime5);
        CutSceneBackground2.RunFade(true);

        yield return new WaitForSeconds(fadeTime3);
        director.Play();
        cam.Priority = 0;
    }
}
