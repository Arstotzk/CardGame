using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;

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

    void Start()
    {
        var masterValue = PlayerPrefs.GetFloat("Master");
        var musicValue = PlayerPrefs.GetFloat("Music");
        var sfxValue = PlayerPrefs.GetFloat("Sfx");
        var slavicValue = PlayerPrefs.GetFloat("Slavic");
        var reptilianValue = PlayerPrefs.GetFloat("Reptilian");

        audioMixer.SetFloat("Master", Mathf.Log10(masterValue) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(musicValue) * 20);
        audioMixer.SetFloat("Sfx", Mathf.Log10(sfxValue) * 20);
        audioMixer.SetFloat("Slavic", Mathf.Log10(slavicValue) * 20);
        audioMixer.SetFloat("Reptilian", Mathf.Log10(reptilianValue) * 20);
    }
}
