using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NovelManager : MonoBehaviour
{
    public List<NovelScript> scripts = new List<NovelScript>();
    public int scriptNumber;
    public GameObject character;
    public GameObject mainText;
    public GameObject background;
    public Deck deck;

    public MusicManager musicManager;
    public MusicManager soundManager;
    public string scriptName;
    public NovelSceneLoader novelSceneLoader;

    public ChooseCard chooseCard;

    private bool isAutoPlay;
    private float autoPlaySpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        scriptNumber = 0;
        isAutoPlay = false;
    }

    public virtual void PlayNextScript()
    {
        if (!this.isActiveAndEnabled)
            return;
        scriptNumber++;
        PlayScript();
    }
    protected void PlayScript()
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

            case NovelScript.ScriptType.startScane:
                string sceneName = ((NovelStartScene)currentScript).sceneName;
                string sceneNameRu = ((NovelStartScene)currentScript).sceneNameRu;
                SceneType sceneType = ((NovelStartScene)currentScript).sceneType;
                novelSceneLoader.SaveAndLoadNextScene(sceneNameRu, sceneName, sceneType);
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

            case NovelScript.ScriptType.changeBackground:
                background.GetComponent<SpriteRenderer>().sprite = ((NovelBackground)currentScript).background;
                break;

            case NovelScript.ScriptType.addCard:
                var instCard = Instantiate(((NovelAddCard)currentScript).card, new Vector3(10, 10, 0), Quaternion.identity);
                instCard.isNovel = true;
                deck.AddCard(instCard, true);
                break;

            case NovelScript.ScriptType.chooseCard:
                var card1 = Instantiate(((NovelChooseCard)currentScript).card1, new Vector3(0, 10, 0), Quaternion.identity);
                card1.isNovel = true;
                var card2 = Instantiate(((NovelChooseCard)currentScript).card2, new Vector3(0, 10, 0), Quaternion.identity);
                card2.isNovel = true;
                chooseCard.SetCurrentNovelManager(this);
                chooseCard.SetCardToChoose(card1, card2);
                break;

            default:
                break;
        }

        if (!currentScript.isAutoNext && !currentScript.isCanAutoPlay)
            isAutoPlay = false;

        if (currentScript.isAutoNext)
            PlayNextScript();
    }
    public virtual void SetIsAutoPlay() 
    {
        isAutoPlay = !isAutoPlay;
        StartCoroutine(AutoPlay());
    }
    private IEnumerator AutoPlay() 
    {
        if (!this.isActiveAndEnabled)
            yield break;

        yield return new WaitForSeconds(autoPlaySpeed);
        Debug.Log(scriptNumber);
        Debug.Log(scripts[scriptNumber]);
        if (scripts[scriptNumber].isCanAutoPlay && isAutoPlay)
        {
            PlayNextScript();
            StartCoroutine(AutoPlay());
        }
    }
}
