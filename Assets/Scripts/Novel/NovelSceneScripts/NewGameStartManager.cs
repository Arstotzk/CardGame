using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameStartManager : NovelManager
{
    // Start is called before the first frame update
    void Start()
    {
        scripts.Add(new NovelSay("Пиздаслав", "Тест текста"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PlayScript()
    {
        base.PlayScript();
        var currentScript = scripts[scriptNumber];

        switch (currentScript.scriptType)
        {
            case NovelScript.ScriptType.mind:

                break;
            case NovelScript.ScriptType.say:
                
                break;
            case NovelScript.ScriptType.world:
                break;
            case NovelScript.ScriptType.action:
                break;
            case NovelScript.ScriptType.startBattle:
                break;
            default:
                break;
        }
    }
}
