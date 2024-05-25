using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCard : MonoBehaviour
{
    // Start is called before the first frame update
    public DropCardToPlace place1;
    public DropCardToPlace place2;
    public Deck deck;
    public GameObject novelPanel;
    public NovelManager novelManager;

    private bool isChoosing = false;

    public bool GetIsChoosing()
    {
        return isChoosing;
    }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChoosing == true)
        {
            if (place1.addedCard.isChoosen == true)
            {
                CardChoosen(place1.addedCard, place1);
            }
            if (place2.addedCard.isChoosen == true)
            {
                CardChoosen(place2.addedCard, place2);
            }
        }
    }

    public void SetCardToChoose(Card card1, Card card2) 
    {
        var animator = GetComponent<Animator>();
        animator.Play("ToBlack");
        //novelPanel.SetActive(false);
        card1.isCanChoose = true;
        card2.isCanChoose = true;
        place1.CardAdded(card1);
        place2.CardAdded(card2);
        isChoosing = true;
    }

    private void CardChoosen(Card card, DropCardToPlace place) 
    {
        var animator = GetComponent<Animator>();
        animator.Play("ToTransparent");
        deck.AddCard(card, true);
        place.addedCard = null;
        place.CardRemove();

        if (place1.addedCard != null)
            place1.addedCard.Delete();
        if (place2.addedCard != null)
            place2.addedCard.Delete();

        //novelPanel.SetActive(true);
        novelManager.PlayNextScript();
        isChoosing = false;
    }

    public void SetCurrentNovelManager(NovelManager _novelManager)
    {
        novelManager = _novelManager;
    }
}
