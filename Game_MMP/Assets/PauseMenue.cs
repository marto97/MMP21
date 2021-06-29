using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenueUI;
    public GameObject PauseOverlay;

     public void MainMenue ()
    {
        Resume();
        SceneManager.LoadScene("MainMenue");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        
    }

    public void Resume ()
    {
        PauseMenueUI.SetActive(false);
        PauseOverlay.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause ()
    {
        PauseMenueUI.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
