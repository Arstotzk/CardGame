using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class NovelSceneLoader : MonoBehaviour
{
    public float secondsLoadDelay = 0.05f;
    const string prefSave = "SaveFile";

    public GameObject novelManager;
    public SaveSerializer saveSerializer;
    void Start()
    {
        //var saveFile = PlayerPrefs.GetString(prefSave);
        saveSerializer = (SaveSerializer)GameObject.FindObjectOfType(typeof(SaveSerializer));
        StartCoroutine(LoadAndSet(secondsLoadDelay, "CurrentScene.dat"));
    }
    private IEnumerator LoadAndSet(float seconds, string saveFile)
    {
        yield return new WaitForSeconds(seconds);
        var saveData = saveSerializer.Load(saveFile);
        ActiveNovelScript(saveData.scene);
    }

    private void ActiveNovelScript(string sceneName)
    {
        var novelManagers = novelManager.GetComponents<NovelManager>();
        novelManagers.Where(nm => nm.scriptName.Equals(sceneName)).FirstOrDefault().enabled = true;
    }

    public void SaveAndLoadNextScene(string nextSceneNameRu, string nextSceneName, SceneType sceneType)
    {
        saveSerializer.Save(nextSceneNameRu, nextSceneName, sceneType, GetPlayerCardPrefabNames(), GetMainCardProperty());
        saveSerializer.CreateCurrentSave(nextSceneNameRu);
        if (sceneType == SceneType.battle)
            SceneManager.LoadScene("BattleScene");
        else
            SceneManager.LoadScene("VisualNovelScene");
    }

    private List<string> GetPlayerCardPrefabNames()
    {
        List<string> cardNames = new List<string>();
        foreach (var card in GetPlayerCards())
        {
            if (card != null)
            {
                cardNames.Add(card.name);
                Debug.Log("Card save: " + card.name);
            }
        }
        return cardNames;
    }

    private List<Card> GetPlayerCards()
    {
        List<Card> cards = new List<Card>();
        return cards;
    }

    private List<int> GetMainCardProperty()
    {
        var mainCardProperty = new List<int>();
        return mainCardProperty;
    }
}
