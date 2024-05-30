using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class NovelSceneLoader : SceneLoader
{
    public GameObject novelManager;
    protected override void Start()
    {
        StartCoroutine(LoadAndSet(secondsLoadDelay, currentFileName));
    }
    protected override IEnumerator LoadAndSet(float seconds, string saveFile)
    {
        yield return new WaitForSeconds(seconds);
        var saveData = saveSerializer.Load(saveFile);
        ActiveNovelScript(saveData.scene);
        LoadPlayerCards(saveData, out var playerCards, out var mainCard);
        foreach (var card in playerCards) 
        {
            card.isNovel = true;
        }
    }

    private void ActiveNovelScript(string sceneName)
    {
        var novelManagers = novelManager.GetComponents<NovelManager>();
        novelManagers.Where(nm => nm.scriptName.Equals(sceneName)).FirstOrDefault().enabled = true;
    }

    protected override List<Card> GetPlayerCards()
    {
        List<Card> cards = deck.cards;
        return cards;
    }
}
