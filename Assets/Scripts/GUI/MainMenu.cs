using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); //Scene number 1 is the Game
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); //Scene number 0 is the MainMenu
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
