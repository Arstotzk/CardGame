using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelBackground : NovelScript
{
    private Sprite _background;
    public Sprite background 
    {
        get => _background;
    }
    public NovelBackground(Sprite inputBackground)
    {
        scriptType = ScriptType.changeBackground;
        _background = inputBackground;
        isAutoNext = true;
    }
}
