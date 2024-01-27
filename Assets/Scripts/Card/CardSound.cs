using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSound : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> SoundOnDeck;
    public List<AudioClip> SoundOnAttack;
    public List<AudioClip> SoundOnDie;
    public List<AudioClip> SoundOnDieSfx;
    public AudioSource audioSourcePerson;
    public AudioSource audioSourceSfx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetOnDeckSoundClip() 
    {
        var clip = SoundOnDeck[Random.Range(0, SoundOnDeck.Count)];
        return clip;
    }
    public AudioClip GetOnAttackSoundClip()
    {
        var clip = SoundOnAttack[Random.Range(0, SoundOnAttack.Count)];
        return clip;
    }
    public AudioClip GetOnDieSoundClip()
    {
        var clip = SoundOnDie[Random.Range(0, SoundOnDie.Count)];
        return clip;
    }
    public AudioClip GetOnDieSfxSoundClip()
    {
        var clip = SoundOnDieSfx[Random.Range(0, SoundOnDieSfx.Count)];
        return clip;
    }

    public float GetLengthCurrentClip() 
    {
        return audioSourcePerson.clip.length;
    }
}
