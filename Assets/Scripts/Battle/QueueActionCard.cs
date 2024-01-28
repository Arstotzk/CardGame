using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueActionCard : QueueAction
{
    private CardPerson card;
    public QueueActionCard(CardPerson _card)
    {
        card = _card;
        status = QueueStatus.NotPlayed;
    }
    public override void Action()
    {
        card.Action();
        status = QueueStatus.Playing;
    }
    public override void AfterAction()
    {
        status = QueueStatus.Played;
    }

    public override Place GetPlace()
    {
        return card.place;
    }

    public override Sprite GetSpriteUI()
    {
        return card.spriteQueueUI;
    }

    public override bool IsAction()
    {
        return card.isAction;
    }
}
