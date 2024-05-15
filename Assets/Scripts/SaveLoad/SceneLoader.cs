using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneLoader : MonoBehaviour
{
    const string mainCardName = "Pizdaslav";
    const string lastSave = "LastSave.dat";
    const string prefSave = "SaveFile";

    public SaveSerializer saveSerializer;
    public BattleManager battleManager;
    public Hand hand;
    public Deck deck;
    public Deck enemyDeck;
    public CardStore cardStore;
    public SceneData currentSceneData;
    public SceneStore sceneStore;

    public float secondsLoadDelay = 1f;
    void Start()
    {
        saveSerializer = (SaveSerializer)GameObject.FindObjectOfType(typeof(SaveSerializer));
        battleManager = (BattleManager)GameObject.FindObjectOfType(typeof(BattleManager));
        StartCoroutine(LoadAndSet(secondsLoadDelay));
    }
    private IEnumerator LoadAndSet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //var saveFile = PlayerPrefs.GetString(prefSave);
        Load("CurrentScene.dat");
        deck.GetStartedCardToHand();
        enemyDeck.GetStartedCardToHand();
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
        var cardsOnBattle = battleManager.GetCardList().Where(c => !c.isEnemy);
        cards.AddRange(cardsOnBattle);
        var cardsOnHand = hand.GetComponentsInChildren<Card>();
        cards.AddRange(cardsOnHand);
        var cardsOnDeck = deck.GetComponentsInChildren<Card>();
        cards.AddRange(cardsOnDeck);
        return cards;
    }

    private List<int> GetMainCardProperty()
    {
        var mainCardProperty = new List<int>();
        var mainCard = GetPlayerCards().Where(mc => mc.name.Contains(mainCardName)).FirstOrDefault();
        foreach (var property in mainCard.cardProperty.properties.Where(p => !p.isNegative && !p.isLengthProperty).ToList())
        {
            mainCardProperty.Add((int)property.type);
        }
        return mainCardProperty;
    }

    public void Load(string saveFile)
    {
        SaveData saveData = saveSerializer.Load(saveFile);
        //«агрузка карт противника
        currentSceneData = sceneStore.GetScene(saveData.scene);
        if (currentSceneData != null)
        {
            foreach (var card in currentSceneData.cards)
            {
                var instCard = Instantiate(card, new Vector3(10, 10, 0), Quaternion.identity);
                enemyDeck.AddCard(instCard, true);
                enemyDeck.GetStartedCardToHand();
            }
            foreach (var cardOnBattle in currentSceneData.cardsOnBattle)
            {
                var place = battleManager.GetPlaceAt(cardOnBattle.column, cardOnBattle.row);
                var instCard = Instantiate(cardOnBattle.card, new Vector3(10, 10, 0), Quaternion.identity);
                instCard.MoveToPlace(place);
            }
        }
        //«агрузка карт игрока
        foreach (var prefabName in saveData.cards)
        {
            Debug.Log("Load card: " + prefabName);
            var card = cardStore.GetCard(prefabName);
            var instCard = Instantiate(card, new Vector3(10, 10, 0), Quaternion.identity);
            deck.AddCard(instCard, false);
            deck.GetStartedCardToHand();

            //TODO пока костыльно передаю свойства карты
            if (prefabName == mainCardName)
            {
                foreach (var property in saveData.mainCardProperty)
                {
                    instCard.GetComponent<CardProperty>().SetProperty((Property.Type)property);
                }
            }
        }
        battleManager.FillCardsArray();
    }

    public void SaveAndLoadNextScene() 
    {
        saveSerializer.Save(currentSceneData.nextSceneNameRu, currentSceneData.nextSceneName, SceneType.novel, GetPlayerCardPrefabNames(), GetMainCardProperty());
        saveSerializer.CreateCurrentSave(currentSceneData.nextSceneNameRu);
        SceneManager.LoadScene("VisualNovelScene");
    }

}
