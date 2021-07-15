using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenue : MonoBehaviour
{
    private static bool GameIsPaused = false;


    public GameObject PauseOverlay;
    public GameObject TimeUpScreen;
    public GameObject PauseMenueScreen;
    public GameObject FinishScreen;

    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

 
    private AudioSource Audio; 

    // called before the first frame
    public void Start(){
        StartCoroutine(CountdownToStart());
        Audio = GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<AudioSource>();
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
        PauseMenueScreen.SetActive(false);
        PauseOverlay.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Audio.Play();

    }

    public void Pause ()
    {
        PauseMenueScreen.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Audio.Pause();
    }

    public void Finish ()
    {
        new WaitForSeconds(2f);
        FinishScreen.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Audio.Pause();
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

        Audio.Pause();
    }

    public void AddToCountdown (int plus)
    {
        countdownTime += plus;
    }

    public void SubFromCountdown (int minus)
    {
        countdownTime -= minus;
    }

    public void NextLevel ()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex < SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        Time.timeScale = 1f;
    }

    public void PlayAgain ()
    {
        Resume();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenue ()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
