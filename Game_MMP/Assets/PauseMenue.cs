using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenue : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenueUI;
    public GameObject PauseOverlay;


    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    public GameObject TimeUpScreen;

    // called before the first frame
    public void Start(){
        StartCoroutine(CountdownToStart());
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


    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "Time is UP!!!";
        TimeUpScreen.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PlayAgain ()
    {   
        Resume();
        SceneManager.LoadScene("levelHUDw");
    }

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
}
