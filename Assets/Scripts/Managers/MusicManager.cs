using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public bool canPlaysMusic = true;
    public bool isMusicPlays = false;
    public void PlayMusic()
    {
        if (isMusicPlays == false)
        {
            audioSource.Play();
            isMusicPlays = true;
        }
    }
    public void StopMusic() 
    {
        isMusicPlays = false;
        audioSource.Stop();
    }
}
