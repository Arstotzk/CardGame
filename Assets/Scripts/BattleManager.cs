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
    public Timer timer;

    public void Start()
    {
        cardsArray = new CardPerson[5, 4];
    }
    public void BattleStart()
    {
        if (!timer.timerOn)
        {
            deployManager.SetNotMovableHand();
            deployManager.SetNotMovableField();
            Debug.Log("BattleStart");

            var cards = GetCardList();
            cards = OrderCardList(cards);
            FillCardsArray();
            ExecCardsActions(cards);

            //Battle End

            deployManager.AddMaxReinforcement(1);
            deployManager.ResetReinforcement();
            deployManager.SetMovableHand();
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
        cards = cards.OrderByDescending(c => c.Initiative).ThenBy(c => c._health).ThenBy(c => c.Attack).ToList();
        return cards;
    }
    public void ExecCardsActions(List<CardPerson> cards)
    {
        Debug.Log("ExecCardsActions");
        float seconds = 0f;
        foreach (var card in cards) 
        {
            Debug.Log("CardAction");
            if (card.IsAnyToAction())
            {
                StartCoroutine(ExecCardAction(card, seconds));
                //�������� �� ������� ������� ����� ����������� ����������� ����� �� �������� �����
                seconds += card.GetFutureActionTime();
            }
        }
        timer.TimerStart(seconds);
    }
    public IEnumerator ExecCardAction(CardPerson card, float seconds) 
    {
        yield return new WaitForSeconds(seconds);
        card.Action();
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
}
