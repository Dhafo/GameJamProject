using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    // Start is called before the first frame update
    public void TogglePause() 
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else 
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        
    }

}
