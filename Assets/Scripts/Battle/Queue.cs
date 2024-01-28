using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public QueueUI queueUI;
    public List<QueueAction> queueActions;
    public int currentPlayingCardNum;
    public bool isPlayBattle;

    void Start()
    {
        queueActions = new List<QueueAction>();
        isPlayBattle = false;
    }

    void Update()
    {
        if (isPlayBattle && queueActions.Count > 0)
        {
            if (queueActions[currentPlayingCardNum].status == QueueAction.QueueStatus.NotPlayed)
                queueActions[currentPlayingCardNum].Action();
            else if (!queueActions[currentPlayingCardNum].IsAction())
            {
                queueActions[currentPlayingCardNum].AfterAction();
                currentPlayingCardNum++;
            }
        }

        if (isPlayBattle && currentPlayingCardNum >= queueActions.Count)
        {
            isPlayBattle = false;
            var battleManager = GetComponentInParent<BattleManager>();
            battleManager.BattleEnd();
        }
    }

    public void FillQueue(List<CardPerson> cards) 
    {

        if (isPlayBattle)
            return;

        queueActions = new List<QueueAction>();
        foreach (var card in cards)
        {
            queueActions.Add(new QueueActionCard(card));
        }

        queueUI.RedrawQueueUI(this);
    }

    public void BattleStarted()
    {
        currentPlayingCardNum = 0;
        isPlayBattle = true;
    }
}
