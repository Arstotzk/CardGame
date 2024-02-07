using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsRow : MonoBehaviour
{
    public GameObject cardPlace1;
    public GameObject cardPlace2;
    public GameObject cardPlace3;
    public GameObject cardPlace4;
    public GameObject cardPlace5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<CardPerson> GetCardInRow()
    {
        var cardList = new List<CardPerson>();
        var cardPlaceList = GetCardPlace();
        foreach (var cardPlace in cardPlaceList) 
        {
            var card = cardPlace.GetComponentInChildren<CardPerson>();
            if (card != null)
            {
                cardList.Add(card);
            }
            else 
            {
                cardList.Add(null);
            }
        }
        return cardList;
    }
    public List<GameObject> GetCardPlace()
    {
        var cardPlaceList = new List<GameObject>();
        cardPlaceList.Add(cardPlace1);
        cardPlaceList.Add(cardPlace2);
        cardPlaceList.Add(cardPlace3);
        cardPlaceList.Add(cardPlace4);
        cardPlaceList.Add(cardPlace5);
        return cardPlaceList;
    }
}
