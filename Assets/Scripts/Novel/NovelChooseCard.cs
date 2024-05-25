using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelChooseCard : NovelScript
{
    private Card _card1;
    public Card card1
    {
        get => _card1;
    }

    private Card _card2;
    public Card card2
    {
        get => _card2;
    }
    public NovelChooseCard(Card initCard1, Card initCard2) 
    {
        scriptType = ScriptType.chooseCard;
        _card1 = initCard1;
        _card2 = initCard2;
        isAutoNext = false;
    }
}
