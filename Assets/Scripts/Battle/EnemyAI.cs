using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject hand;
    public List<Coord> coordinates;
    public BattleManager battleManager;
    public struct Coord
    {
        public Coord(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public override string ToString() => $"({Row}, {Column})";
    }
    // Start is called before the first frame update
    void Start()
    {
        coordinates = new List<Coord>();
        for (int row = 0; row <= 1; row++)
        {
            for (int column = 0; column <= 4; column++)
            {
                coordinates.Add(new Coord(row, column));
            }
        }
    }
    public CardPerson GetRandomCard() 
    {
        var cards = hand.GetComponentsInChildren<CardPerson>();
        var number = Random.Range(0, cards.Length);
        var card = cards[number];
        return card;
    }

    /// <summary>
    /// Получить позицию для карты, на которой она сможет атаковать хотябы одну карту игрока.
    /// </summary>
    /// <param name="card"></param>
    public Place GetPlace(CardPerson card)
    {
        for (int iteration = 0; iteration <= 9; iteration++)
        {
            var number1 = Random.Range(0, 9);
            var number2 = Random.Range(0, 9);
            var coord1 = coordinates[number1];
            var coord2 = coordinates[number2];
            coordinates[number1] = coord2;
            coordinates[number2] = coord1;
        }

        foreach (var coord in coordinates)
        {
            card.row = coord.Row;
            card.column = coord.Column;
            var cardAtPlace = battleManager.GetCardAt(coord.Column, coord.Row);
            if (cardAtPlace == null)
            {
                var isAnyToAction = card.IsAnyToAction();
                if (isAnyToAction)
                    return battleManager.GetPlaceAt(coord.Column, coord.Row);
            }
        }
        //В любом положении нет карт для атаки, значит ставим карту в рандомное место
        foreach (var coord in coordinates)
        {
            card.row = coord.Row;
            card.column = coord.Column;
            var cardAtPlace = battleManager.GetCardAt(coord.Column, coord.Row);
            if (cardAtPlace == null)
            {
                return battleManager.GetPlaceAt(coord.Column, coord.Row);
            }
        }
        return null;
    }

    public void SetCardToBattle() 
    {
        if (hand.GetComponentsInChildren<CardPerson>().Length == 0)
            return;
        var cardFromHand = GetRandomCard();
        var place = GetPlace(cardFromHand);
        if (place == null)
            return;
        cardFromHand.SetToPlace(place);
    }
}
