using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeployManager : MonoBehaviour
{

    int _reinforcement;
    public int Reinforcement 
    { 
        get => _reinforcement;
        set 
        {
            _reinforcement = value;
            ReinforcementText.text = value.ToString();
        } 
    }
    public int limitReinforcement;
    public int maxReinforcement;
    public TMP_Text ReinforcementText;

    public GameObject hand;
    public GameObject firstLineGround;
    public GameObject secondLineGround;

    public bool isPlayerDrugCard;
    // Start is called before the first frame update
    void Start()
    {
        Reinforcement = maxReinforcement;
        isPlayerDrugCard = false;
        SetMovableHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaxReinforcement(int value) 
    {
        if(maxReinforcement < limitReinforcement)
            maxReinforcement += value;
    }
    public void ResetReinforcement() 
    {
        Reinforcement = maxReinforcement;
    }

    public void SetMovableHand() 
    {
        var cardInHand = hand.GetComponentsInChildren<Card>();
        foreach (var card in cardInHand)
        {
            card.isMoveable = true;
        }
    }
    public void SetNotMovableHand()
    {
        var cardInHand = hand.GetComponentsInChildren<Card>();
        foreach (var card in cardInHand)
        {
            card.isMoveable = false;
        }
    }
    public void SetNotMovableField()
    {
        var cardOnFirstLineGround = firstLineGround.GetComponentsInChildren<CardPerson>();
        var cardOnSecondLineGround = secondLineGround.GetComponentsInChildren<CardPerson>();
        CardPerson[] cardOnGround = new CardPerson[cardOnFirstLineGround.Length + cardOnSecondLineGround.Length];
        cardOnFirstLineGround.CopyTo(cardOnGround, 0);
        cardOnSecondLineGround.CopyTo(cardOnGround, cardOnFirstLineGround.Length);
        foreach (var card in cardOnGround)
        {
            card.isMoveable = false;
        }
    }
    public void PutCardFromBufferToHand(Card card)
    {
        card.transform.SetParent(hand.transform);
        var dctPlace = hand.GetComponent<DropCardToPlace>();
        dctPlace.CardAdded(card);
    }
}
