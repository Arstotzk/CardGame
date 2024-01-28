using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QueueAction
{
    public QueueStatus status;
    public abstract void Action();
    public abstract void AfterAction();
    public abstract bool IsAction();

    public abstract Place GetPlace();

    public abstract Sprite GetSpriteUI();

    public enum QueueStatus 
    {
        NotPlayed,
        Playing,
        Played
    }
}
