using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadToVillage : NovelManager
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelMind("Test save"));
        PlayScript();
    }
}
