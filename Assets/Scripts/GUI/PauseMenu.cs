using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject GameOverScreen;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverScreen.activeSelf)
        {
            Debug.Log("ax me patas");
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freezes the game
        isPaused = true;
    }

}
