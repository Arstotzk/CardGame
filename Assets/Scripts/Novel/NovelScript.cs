using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NovelScript
{
    public bool isAutoNext;
    public ScriptType scriptType; 
    public NovelScript()
    {

    }
    public virtual void Play()
    {

    }
    public enum ScriptType 
    {
        mind,
        say,
        world,
        action,
        startBattle,
        musicStart,
        musicStop,
        soundPlay
    }
}