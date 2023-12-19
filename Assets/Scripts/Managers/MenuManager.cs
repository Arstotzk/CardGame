using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<AudioClip> SoundBattle;
    public List<AudioClip> SoundSlavic;
    public List<AudioClip> SoundReptilian;
    public AudioClip SoundShutUp;
    public bool isShutUpPlayed;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        isShutUpPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Setting() 
    {

    }
    public void Continue()
    {

    }

    public void NewGame() 
    {

    }
    public void MusicValueChanged(float value) 
    {
        
    }
    public void BattleValueChanged(float value)
    {
        audioSource.volume = value;
        if (!audioSource.isPlaying)
        {
            var clip = SoundBattle[Random.Range(0, SoundBattle.Count)];
            audioSource.clip = clip;
            audioSource.volume = value;
            audioSource.Play();
        }
    }
    public void SlavicValueChanged(float value)
    {
        audioSource.volume = value;
        if (!audioSource.isPlaying)
        {
            var clip = SoundSlavic[Random.Range(0, SoundSlavic.Count)];
            audioSource.clip = clip;
            audioSource.volume = value;
            audioSource.Play();
        }
    }
    public void ReptilianValueChanged(float value)
    {
        if (value == 0)
        {
            audioSource.clip = SoundShutUp;
            //Todo брать громкость русов
            audioSource.volume = 0.8f;
            audioSource.Play();
        }
        else
        {
            audioSource.volume = value;
            if (!audioSource.isPlaying)
            {
                var clip = SoundReptilian[Random.Range(0, SoundReptilian.Count)];
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }

    public void SaveSettings() 
    {

    }

    public void CancelSettings() 
    {

    }
}
