using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelSay : NovelScript
{
    private string _character;
    public string character 
    { 
        get => _character;
    }
    private string _text;
    public string text
    {
        get => _text;
    }
    public NovelSay(string inputCharacter, string inputText)
    {
        //Добавить говорящего и его полдожение на сцене
        scriptType = ScriptType.say;
        _character = inputCharacter;
        _text = inputText;
        isCanAutoPlay = true;
    }
    public override void Play()
    {

    }
}
