using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused;
    void Start()
    {
       
    }
    public void PauseGame(bool boolean)
    {
        isPaused = boolean;
    }
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }
    }
}
