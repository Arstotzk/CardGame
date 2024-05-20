using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShow : MonoBehaviour
{
    // Start is called before the first frame update
    private Deck deck;
    public DropCardToPlace firstLine;
    public DropCardToPlace secondLine;
    public DropCardToPlace thirdLine;
    private bool isShowing = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(Deck _deck)
    {
        deck = _deck;
        if (isShowing == true)
        {
            Unshow();
            return;
        }
        var animator = GetComponent<Animator>();
        animator.Play("ToBlack");

        var cards = new List<Card>();
        cards.AddRange(deck.cards);
        DropCardToPlace currentLine = firstLine;
        int cardsNum = 0;

        foreach (var card in cards)
        {
            cardsNum++;
            card.transform.parent = currentLine.transform;
            var rotation = card.transform.rotation;
            rotation.x = 0;
            card.transform.rotation = rotation;

            card.OrderLayerUp(20);
            deck.cards.Remove(card);
            currentLine.CardAdded(card);
            if (cardsNum == 6)
                currentLine = secondLine;
            else if (cardsNum == 12)
                currentLine = thirdLine;
        }
        isShowing = true;
        Debug.Log("DeckShow");
    }
    public void Unshow()
    {
        var animator = GetComponent<Animator>();
        animator.Play("ToTransparent");
        foreach (var card in firstLine.movedCards)
        {
            card.transform.parent = deck.transform;
            card.OrderLayerDown(20);
            deck.AddCard(card, true);
        }
        firstLine.CardRemove();

        foreach (var card in secondLine.movedCards)
        {
            card.transform.parent = deck.transform;
            card.OrderLayerDown(20);
            deck.AddCard(card, true);
        }
        secondLine.CardRemove();

        foreach (var card in thirdLine.movedCards)
        {
            card.transform.parent = deck.transform;
            card.OrderLayerDown(20);
            deck.AddCard(card, true);
        }
        thirdLine.CardRemove();

        isShowing = false;
    }
}
