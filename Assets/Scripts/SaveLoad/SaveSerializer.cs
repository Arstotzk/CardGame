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
    public BattleManager battleManager;
    public Hand hand;
    public Deck deck;
    // Start is called before the first frame update
    void Start()
    {
        battleManager = (BattleManager)GameObject.FindObjectOfType(typeof(BattleManager));
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
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        saveData.scene = SceneManager.GetActiveScene().name;
        saveData.cards = GetPlayerCards();
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game data saved");
    }
}
