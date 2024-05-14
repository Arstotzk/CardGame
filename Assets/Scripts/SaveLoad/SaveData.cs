using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public string scene;
    public List<string> cards;
    public List<int> mainCardProperty;
    public SceneType sceneType;
}
