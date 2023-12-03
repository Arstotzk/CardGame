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
        if (canPlaysMusic == true && isMusicPlays == false)
        {
            audioSource.Play();
            isMusicPlays = true;
        }
    }
    public void StopMusic() 
    {
        canPlaysMusic = false;
        isMusicPlays = false;
        audioSource.Stop();
    }
}
