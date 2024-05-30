using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class BattleSceneLoader : SceneLoader
{
    public BattleManager battleManager;
    public Hand hand;
    public Deck enemyDeck;
    public SceneData currentSceneData;
    public SceneStore sceneStore;

    protected override void Start()
    {
        base.Start();
        saveSerializer = (SaveSerializer)GameObject.FindObjectOfType(typeof(SaveSerializer));
        battleManager = (BattleManager)GameObject.FindObjectOfType(typeof(BattleManager));
        StartCoroutine(LoadAndSet(secondsLoadDelay, currentFileName));
    }
    protected override IEnumerator LoadAndSet(float seconds, string saveFile)
    {
        yield return new WaitForSeconds(seconds);
        //var saveFile = PlayerPrefs.GetString(prefSave);
        Load(currentFileName);
        deck.GetStartedCardToHand();
        enemyDeck.GetStartedCardToHand();
    }
    protected override List<Card> GetPlayerCards()
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

    public void Load(string saveFile)
    {
        SaveData saveData = saveSerializer.Load(saveFile);
        //Загрузка карт противника
        var enemyCards = new List<Card>();
        currentSceneData = sceneStore.GetScene(saveData.scene);
        if (currentSceneData != null)
        {
            foreach (var card in currentSceneData.cards)
            {
                var instCard = Instantiate(card, new Vector3(10, 10, 0), Quaternion.identity);
                enemyCards.Add(instCard);
                enemyDeck.AddCard(instCard, true);
            }
            foreach (var cardOnBattle in currentSceneData.cardsOnBattle)
            {
                var place = battleManager.GetPlaceAt(cardOnBattle.column, cardOnBattle.row);
                var instCard = Instantiate(cardOnBattle.card, new Vector3(10, 10, 0), Quaternion.identity);
                enemyCards.Add(instCard);
                instCard.MoveToPlace(place);
            }
        }
        //Загрузка карт игрока
        LoadPlayerCards(saveData, out var playerCards, out var mainCard);

        battleManager.FillCardsArray();
        battleManager.SetCardsObjective(mainCard, enemyCards, playerCards);
    }
}
