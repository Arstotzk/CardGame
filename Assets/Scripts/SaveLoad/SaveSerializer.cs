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
    public BattleManager battleManager;
    public Hand hand;
    public Deck deck;
    public CardStore cardStore;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = (BattleManager)GameObject.FindObjectOfType(typeof(BattleManager));
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
        var saveData = new SaveData();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        saveData.scene = SceneManager.GetActiveScene().name;
        saveData.cards = GetPlayerCardPrefabNames();
        saveData.mainCardProperty = new List<int>();
        var mainCard = GetPlayerCards().Where(mc => mc.name == mainCardName).FirstOrDefault();
        foreach (var property in mainCard.cardProperty.properties.Where(p => !p.isNegative && !p.isLengthProperty).ToList())
        {
            saveData.mainCardProperty.Add((int)property.type);
        }
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game data saved");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();
            foreach (var prefabName in saveData.cards)
            {
                Debug.Log("Load card: " + prefabName);
                var card = cardStore.GetCard(prefabName);
                var instCard = Instantiate(card, new Vector3(10, 10, 0), Quaternion.identity);
                deck.AddCard(instCard, false);

                //TODO пока костыльно передаю свойства карты
                if (prefabName == mainCardName)
                {
                    foreach (var property in saveData.mainCardProperty) 
                    {
                        instCard.GetComponent<CardProperty>().SetProperty((Property.Type) property);
                    }
                }
            }
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}

