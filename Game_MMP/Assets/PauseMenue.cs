using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
     public void MainMenue ()
    {
        SceneManager.LoadScene("MainMenue");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
