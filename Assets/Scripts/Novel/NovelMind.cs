using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelMind : NovelScript
{
    private string _text;
    public string text
    {
        get => _text;
    }
    public NovelMind(string inputText)
    {
        scriptType = ScriptType.mind;
        _text = inputText;
    }
}
