using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelAddCard : NovelScript
{
    private Card _card;
    public Card card
    {
        get => _card;
    }

    public NovelAddCard(Card initCard)
    {
        scriptType = ScriptType.addCard;
        _card = initCard;
        isAutoNext = true;
    }
}
