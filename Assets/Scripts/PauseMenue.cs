using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenue : MonoBehaviour
{
    // always true when game is paused -> timescale = 0
    private static bool GameIsPaused = false;


    // Gameobjects thet need to be referenced for SetActive()
    public GameObject PauseOverlay;
    public GameObject Damage;
    public GameObject Healing;
    public GameObject TimeUpScreen;
    public GameObject PauseMenueScreen;
    public GameObject FinishScreen;

    // Countdown: Time and several displays
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    public TextMeshProUGUI countdownMinus;
    public TextMeshProUGUI countdownPlus;
    public TextMeshProUGUI Score;


    // Audio
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


    // Resuming the game
    public void Resume ()
    {
        PauseMenueScreen.SetActive(false);
        PauseOverlay.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Audio.Play();

    }

    // Pausing the game
    public void Pause ()
    {
        PauseMenueScreen.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Audio.Pause();
    }

    // Is called when CharacterController2D detects collision with the doenerstand
    public void Finish ()
    {
        FinishScreen.SetActive(true);
        PauseOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Score.text = "SCORE: " + countdownTime + " SECONDS LEFT";

        Audio.Pause();
    }


    // Handles the time countdown and gameover
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
        countdownPlus.text = "+" + plus;
        StartCoroutine(CountdownDisplay(1));
    }

    public void SubFromCountdown (int minus)
    {
        countdownTime -= minus;
        countdownMinus.text = "-" + minus;
        StartCoroutine(CountdownDisplay(0));
    }
    
    // Handles the damage/healing overlays
    IEnumerator CountdownDisplay (int i)
    {
        if (i == 0)
        {
            Damage.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Damage.SetActive(false);
        }
        if (i == 1)
        {
            Healing.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Healing.SetActive(false);
        }

    }

    // Logic for several buttons
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
