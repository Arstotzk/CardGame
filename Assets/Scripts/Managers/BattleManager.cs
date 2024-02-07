using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BattleManager : MonoBehaviour
{
    public DeployManager deployManager;
    public CardsRow enemyBack;
    public CardsRow enemyFront;
    public CardsRow allyFront;
    public CardsRow allyBack;
    public CardPerson[,] cardsArray;
    public Place[,] cardPlaces;
    public Timer timer;
    public int roundNum;
    public EnemyAI enemyAI;
    public Queue queue;
    public Deck deckSlav;
    public Deck deckEnemy;
    public Deck discardSlav;
    public Deck discardEnemy;

    public SoundManager smSlavic;
    public SoundManager smReptilian;
    public Button battleButton;

    public bool isBattleActive;
    public bool isAnyoneDied;

    public void Start()
    {
        cardsArray = new CardPerson[5, 4];
        cardPlaces = new Place[5, 4];
        roundNum = 0;
        isBattleActive = false;
        FillCardPlaces();
        FillCardsArray();
        isAnyoneDied = false;
    }

    public void BattleStart()
    {
        if (!timer.timerOn)
        {
            isBattleActive = true;
            deployManager.SetAllMovable(false);
            Debug.Log("BattleStart");

            var cards = GetCardList();
            cards = OrderCardList(cards);
            FillCardsArray();
            //FillCardsSounds(cards);
            queue.BattleStarted();
            /*
            var seconds = ExecCardsActions(cards);

            //Battle End
            roundNum++;
            //Потом сделать по нормальному, менеджер очереди
            if (roundNum > 2)
                StartCoroutine(ResetReinforsmentToDeployManager(seconds + 4));
            else
                StartCoroutine(ResetReinforsmentToDeployManager(seconds + 4));
            StartCoroutine(StartRoundScript(seconds));
            */
        }
    }
    public void BattleEnd()
    {
        roundNum++;
        StartRoundScript();
        deckSlav.GetRandomCardToHand();
        deckEnemy.GetRandomCardToHand();
    }
    public void FillCardsSounds(List<CardPerson> cards) 
    {
        foreach (var card in cards) 
        {
            if (card.isEnemy)
            {
                //card.SoundOnAttack.clip = smReptilian.GetOnAttackSoundClip();
                //card.SoundOnDeck.clip = smReptilian.GetOnDeckSoundClip();
                //card.SoundOnDeath.clip = smReptilian.GetOnDieSoundClip();
            }
            else
            {
                //if (!card.isUniqueAttack)
                    //card.SoundOnAttack.clip = smSlavic.GetOnAttackSoundClip();
                //card.SoundOnDeck.clip = smSlavic.GetOnDeckSoundClip();
                //card.SoundOnDeath.clip = smSlavic.GetOnDieSoundClip();
            }
        }
    }

    public List<CardPerson> GetCardList()
    {
        var cards = new List<CardPerson>();
        cards.AddRange(enemyBack.GetCardInRow().Where(c => c != null));
        cards.AddRange(enemyFront.GetCardInRow().Where(c => c != null));
        cards.AddRange(allyFront.GetCardInRow().Where(c => c != null));
        cards.AddRange(allyBack.GetCardInRow().Where(c => c != null));
        return cards;
    }
    public void FillCardPlaces() 
    {
        var cardPlacesList = new List<Place>();
        foreach (GameObject cardPlace in GetCardPlacesList())
        {
            var place = cardPlace.GetComponent<Place>();
            cardPlaces[place.column, place.row] = place;
        }
    }
    public List<GameObject> GetCardPlacesList()
    {
        var list = new List<GameObject>();
        list.AddRange(enemyBack.GetCardPlace());
        list.AddRange(enemyFront.GetCardPlace());
        list.AddRange(allyFront.GetCardPlace());
        list.AddRange(allyBack.GetCardPlace());
        return list;
    }
    public void FillCardsArray()
    {
        var cardsEnemyBack = enemyBack.GetCardInRow();
        FillCardsArrayRow(cardsEnemyBack, 0);
        var cardsEnemyFront = enemyFront.GetCardInRow();
        FillCardsArrayRow(cardsEnemyFront, 1);
        var cardsAllyFront = allyFront.GetCardInRow();
        FillCardsArrayRow(cardsAllyFront, 2);
        var cardsAllyBack = allyBack.GetCardInRow();
        FillCardsArrayRow(cardsAllyBack, 3);

        var cards = GetCardList();
        cards = OrderCardList(cards);
        queue.FillQueue(cards);
    }
    public void FillCardsArrayRow(List<CardPerson> cardsRow, int rowNum) 
    {
        for (var i = 0; i <= 4; i++)
        {
            cardsArray[i,rowNum] = cardsRow[i];
            if (cardsRow[i] != null)
            {
                cardsRow[i].column = i;
                cardsRow[i].row = rowNum;
            }
        }
    }
    public List<CardPerson> OrderCardList(List<CardPerson> cards) 
    {
        cards = cards.OrderByDescending(c => c.initiative).ThenBy(c => c._health).ThenBy(c => c._attack).ToList();
        return cards;
    }
    public float ExecCardsActions(List<CardPerson> cards)
    {
        Debug.Log("ExecCardsActions");
        float seconds = 0f;
        foreach (var card in cards) 
        {
            StartCoroutine(ExecBeforeCardAction(card, seconds));
            Debug.Log("CardAction");
            if (card.IsAnyToAction())
            {
                StartCoroutine(ExecCardAction(card, seconds));
                //изменить на функцию которая будет расчитывать необходимое время на анимации карты
                seconds += card.GetFutureActionTime();
            }
        }
        timer.TimerStart(seconds);
        return seconds;
    }
    public IEnumerator ExecCardAction(CardPerson card, float seconds) 
    {
        yield return new WaitForSeconds(seconds);
        card.Action();
    }
    public IEnumerator ExecBeforeCardAction(CardPerson card, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        card.BeforeAction();
    }

    public void StartRoundScript()
    {
        //Сделать еще скриптовые раунды в который определенные карты выставляются, а не рандомные
        var card = enemyAI.SetCardToBattle();
        FillCardsArray();
        enemyAI.MoveCardOnBattleground();
        FillCardsArray();
        if (roundNum > 2 && card != null)
        {
            StartCoroutine(StartSetEnemyCard(card.sound.GetLengthCurrentClip()));
        }
        else
            ResetReinforsmentToDeployManager();
    }

    public IEnumerator StartSetEnemyCard(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        enemyAI.SetCardToBattle();
        FillCardsArray();
        ResetReinforsmentToDeployManager();
    }
    public void ResetReinforsmentToDeployManager() 
    {
        isBattleActive = false;
        deployManager.AddMaxReinforcement(1);
        deployManager.ResetReinforcement();
        deployManager.SetAllMovable(true);
        battleButton.EndBattle();
    }
    public CardPerson GetCardAt(int column, int row) 
    {
        try
        {
            return cardsArray[column, row];
        }
        catch 
        {
            return null;
        }
    }
    public Place GetPlaceAt(int column, int row)
    {
        try
        {
            return cardPlaces[column, row];
        }
        catch
        {
            return null;
        }
    }

    public float GetLongestDieSoundLength() 
    {
        var dieSoundLength = 0f;
        var diedCards = GetCardList().Where(c => c.isDead);
        foreach (var card in diedCards)
        {
            if (dieSoundLength < card.sound.GetLengthCurrentClip())
                dieSoundLength = card.sound.GetLengthCurrentClip();
        }
        return dieSoundLength;
    }
}
