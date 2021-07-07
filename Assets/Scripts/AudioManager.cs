using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void pause()
    {
      audioSource = GetComponent<AudioSource>();
      audioSource.Pause();
    }

    public void resume()
    {
      audioSource = GetComponent<AudioSource>();
      audioSource.Play(0);
    }
}
