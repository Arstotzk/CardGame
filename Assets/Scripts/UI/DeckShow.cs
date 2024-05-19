using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShow : MonoBehaviour
{
    // Start is called before the first frame update
    private Deck deck;
    public DropCardToPlace firstLine;
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
        foreach (var card in deck.cards)
        {
            card.transform.parent = firstLine.transform;
            card.OrderLayerUp(20);
            firstLine.CardAdded(card);
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
            deck.AddCard(card);
        }
        isShowing = false;
    }
}
