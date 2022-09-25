using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    public void TogglePause() 
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePause();
        }
    }

}
