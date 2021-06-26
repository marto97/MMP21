using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
  
    public void PlayGame ()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayLevel1 ()
    {
        SceneManager.LoadScene("level_1");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
