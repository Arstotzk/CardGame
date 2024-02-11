using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> cards;
    public DropCardToPlace hand;

    void Start()
    {

    }

    public void Init()
    {
        var currentCards = GetComponentsInChildren<Card>();
        foreach (var card in currentCards)
        {
            cards.Add(card);
        }
    }

    public void GetRandomCardToHand() 
    {
        if (cards.Count > 0)
        {
            var num = cards.Count - 1;
            var random = Random.Range(0, num);
            var card = cards[random];
            card.transform.parent = hand.transform;
            card.isFromHand = true;
            card.isMoveable = true;
            hand.CardAdded(card);
            cards.Remove(card);
        }
    }

    public void AddCard(Card card)
    {
        card.transform.position = this.transform.position;
        var rotation = card.transform.rotation;
        rotation.x = 180;
        card.transform.rotation = rotation;
        card.transform.parent = this.transform;
        card.CurrentParent = this.transform;
        card.isMoveable = false;
        cards.Add(card);
    }
    public void AddCard(Card card, bool isFlip)
    {
        card.transform.position = this.transform.position;
        if (isFlip)
        {
            var rotation = card.transform.rotation;
            rotation.x = 180;
            card.transform.rotation = rotation;
        }
        card.transform.parent = this.transform;
        card.CurrentParent = this.transform;
        card.isMoveable = false;
        cards.Add(card);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
