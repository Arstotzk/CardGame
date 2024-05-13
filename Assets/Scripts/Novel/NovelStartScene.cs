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

    private SceneType _sceneType;
    public SceneType sceneType
    {
        get => _sceneType;
    }
    public NovelStartScene(string inputSceneName, SceneType novelStartSceneType)
    {
        scriptType = ScriptType.startScane;
        _sceneName = inputSceneName;
        _sceneType = novelStartSceneType;
    }
    public enum SceneType
    {
        novel,
        battle
    }
}
