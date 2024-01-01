using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelStartScene : NovelScript
{
    private string _sceneName;
    public string sceneName
    {
        get => _sceneName;
    }
    public NovelStartScene(string inputSceneName)
    {
        scriptType = ScriptType.startScane;
        _sceneName = inputSceneName;
    }
}
