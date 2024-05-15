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

    private string _sceneNameRu;
    public string sceneNameRu
    {
        get => _sceneNameRu;
    }

    private SceneType _sceneType;
    public SceneType sceneType
    {
        get => _sceneType;
    }
    public NovelStartScene(string inputSceneName, string inputSceneNameRu, SceneType novelStartSceneType)
    {
        scriptType = ScriptType.startScane;
        _sceneName = inputSceneName;
        _sceneNameRu = inputSceneNameRu;
        _sceneType = novelStartSceneType;
    }
}
