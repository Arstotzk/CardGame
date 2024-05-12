using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveSerializer : MonoBehaviour
{
    const string mainCardName = "Pizdaslav";
    const string lastSave = "LastSave.dat";
    const string prefSave = "SaveFile";
    public BattleManager battleManager;
    public Hand hand;
    public Deck deck;
    public Hand enemyHand;
    public Deck enemyDeck;
    public CardStore cardStore;
    public SceneData currentSceneData;
    public SceneStore sceneStore;

    public float secondsLoadDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = (BattleManager)GameObject.FindObjectOfType(typeof(BattleManager));
        StartCoroutine(LoadAndSet(secondsLoadDelay));
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
    public void Save()
    {
        Save(lastSave);
    }

    public void Save(string saveFile)
    {
        var saveData = new SaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFile);
        saveData.scene = currentSceneData.Name; //Надо передавать следующую сцену
        saveData.cards = GetPlayerCardPrefabNames();
        saveData.mainCardProperty = new List<int>();
        var mainCard = GetPlayerCards().Where(mc => mc.name.Contains(mainCardName)).FirstOrDefault();
        foreach (var property in mainCard.cardProperty.properties.Where(p => !p.isNegative && !p.isLengthProperty).ToList())
        {
            saveData.mainCardProperty.Add((int)property.type);
        }
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game data saved");
    }

    public void Load(string saveFile)
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFile, FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();
            //Загрузка карт противника
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
            //Загрузка карт игрока
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
                        instCard.GetComponent<CardProperty>().SetProperty((Property.Type) property);
                    }
                }
            }
            battleManager.FillCardsArray();
            Debug.Log("Game data loaded! SaveFile: " + saveFile);
        }
        else
            Debug.LogError("There is no save data! SaveFile: " + saveFile);
    }

    private IEnumerator LoadAndSet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        var saveFile = PlayerPrefs.GetString(prefSave);
        Load(saveFile);
        deck.GetStartedCardToHand();
        enemyDeck.GetStartedCardToHand();
    }
}

