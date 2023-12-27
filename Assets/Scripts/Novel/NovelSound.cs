using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelSound : NovelScript
{
    AudioClip _audioClip;
    public AudioClip audioClip 
    {
        get => _audioClip;
    }
    public NovelSound(AudioClip inputAudioClip)
    {
        if (inputAudioClip == null)
            scriptType = ScriptType.soundStop;
        else
            scriptType = ScriptType.soundPlay;
        isAutoNext = true;
        _audioClip = inputAudioClip;
    }
}
