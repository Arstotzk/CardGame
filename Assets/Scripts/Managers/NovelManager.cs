using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NovelManager : MonoBehaviour
{
    public List<NovelScript> scripts = new List<NovelScript>();
    public int scriptNumber;
    public GameObject character;
    public GameObject mainText;
    // Start is called before the first frame update
    void Start()
    {
        scriptNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void PlayNextScript()
    {
        scriptNumber++;
        PlayScript();
    }
    public virtual void PlayScript()
    {
        Debug.Log("PlayScript: " + scriptNumber);
        var currentScript = scripts[scriptNumber];

        switch (currentScript.scriptType)
        {
            case NovelScript.ScriptType.mind:
                break;
            case NovelScript.ScriptType.say:
                character.GetComponentInChildren<TMP_Text>(true).text = ((NovelSay) currentScript).character;
                mainText.GetComponentInChildren<TMP_Text>(true).text = ((NovelSay)currentScript).text;
                break;
            case NovelScript.ScriptType.world:
                break;
            case NovelScript.ScriptType.action:
                break;
            case NovelScript.ScriptType.startBattle:
                break;
            case NovelScript.ScriptType.musicStart:
                break;
            case NovelScript.ScriptType.musicStop:
                break;
            case NovelScript.ScriptType.soundPlay:
                break;
            default:
                break;
        }
    }
}
