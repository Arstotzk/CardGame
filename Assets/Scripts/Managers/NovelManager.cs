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

    public MusicManager musicManager;
    public MusicManager soundManager;
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
                character.SetActive(false);
                mainText.SetActive(true);
                mainText.GetComponentInChildren<TMP_Text>(true).text = ((NovelMind)currentScript).text;
                break;
            case NovelScript.ScriptType.say:
                character.SetActive(true);
                mainText.SetActive(true);
                character.GetComponentInChildren<TMP_Text>(true).text = ((NovelSay) currentScript).character;
                mainText.GetComponentInChildren<TMP_Text>(true).text = ((NovelSay)currentScript).text;
                break;
            case NovelScript.ScriptType.world:
                break;
            case NovelScript.ScriptType.action:
                break;
            case NovelScript.ScriptType.startBattle:
                break;
            case NovelScript.ScriptType.musicPlay:
                musicManager.audioSource.clip = ((NovelMusic)currentScript).audioClip;
                musicManager.PlayMusic();
                break;
            case NovelScript.ScriptType.musicStop:
                musicManager.audioSource.clip = null;
                musicManager.StopMusic();
                break;
            case NovelScript.ScriptType.soundPlay:
                soundManager.StopMusic();
                soundManager.audioSource.clip = ((NovelSound)currentScript).audioClip;
                soundManager.PlayMusic();
                break;
            case NovelScript.ScriptType.soundStop:
                soundManager.audioSource.clip = null;
                soundManager.StopMusic();
                break;
            default:
                break;
        }

        if (currentScript.isAutoNext)
            PlayNextScript();
    }
}
