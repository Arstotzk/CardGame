using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneLoader : MonoBehaviour
{
    protected const string mainCardName = "Pizdaslav";
    protected const string currentFileName = "CurrentScene";
    public float secondsLoadDelay = 0.05f;

    public SaveSerializer saveSerializer;
    public CardStore cardStore;
    public Deck deck;

    protected virtual void Start()
    {
        saveSerializer = (SaveSerializer)GameObject.FindObjectOfType(typeof(SaveSerializer));
    }

    protected virtual IEnumerator LoadAndSet(float seconds, string saveFile)
    {
        yield return new WaitForSeconds(seconds);
    }

    protected virtual List<string> GetPlayerCardPrefabNames()
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

    protected virtual List<Card> GetPlayerCards()
    {
        List<Card> cards = new List<Card>();
        return cards;
    }

    protected virtual List<int> GetMainCardProperty()
    {
        var mainCardProperty = new List<int>();
        var mainCard = GetPlayerCards().Where(mc => mc.name.Contains(mainCardName)).FirstOrDefault();
        var propeties = mainCard.cardProperty.properties.Where(p => !p.isNegative && !p.isLengthProperty).ToList();
        foreach (var property in propeties)
        {
            mainCardProperty.Add((int)property.type);
        }
        return mainCardProperty;
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

    protected virtual void LoadPlayerCards(SaveData saveData, out List<Card> playerCards, out Card mainCard) 
    {
        playerCards = new List<Card>();
        mainCard = null;

        foreach (var prefabName in saveData.cards)
        {
            Debug.Log("Load card: " + prefabName);
            var cardFromStore = cardStore.GetCard(prefabName);
            var instCard = Instantiate(cardFromStore, new Vector3(10, 10, 0), Quaternion.identity);
            playerCards.Add(instCard);
            deck.AddCard(instCard, true);

            //TODO пока костыльно передаю свойства карты
            if (prefabName.Contains(mainCardName))
            {
                mainCard = instCard;
                foreach (var property in saveData.mainCardProperty)
                {
                    instCard.GetComponent<CardProperty>().SetProperty((Property.Type)property);
                }
            }
        }
        return;
    }
}
