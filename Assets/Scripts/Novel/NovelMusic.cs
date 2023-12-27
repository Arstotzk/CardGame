using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelMusic : NovelScript
{
    AudioClip _audioClip;
    public AudioClip audioClip
    {
        get => _audioClip;
    }
    public NovelMusic(AudioClip inputAudioClip)
    {
        if (inputAudioClip == null)
            scriptType = ScriptType.musicStop;
        else
            scriptType = ScriptType.musicPlay;
        isAutoNext = true;
        _audioClip = inputAudioClip;
    }
}
