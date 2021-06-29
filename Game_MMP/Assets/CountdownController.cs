using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    public GameObject TimeUpScreen;

    public void Start(){
        StartCoroutine(CountdownToStart());
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
    }
}
