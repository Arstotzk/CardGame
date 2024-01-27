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

    public override bool IsAction()
    {
        return card.isAction;
    }
}
