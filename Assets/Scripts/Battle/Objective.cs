using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Objective : MonoBehaviour
{
    public Card mainCard;
    public List<Card> enemyCards;
    public List<Card> playerCards;

    public bool isObjectiveMainCardAlive = true;
    public bool isObjectiveEnemyCardsDead = true;
    public bool isObjectivePlayerCardsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ObjectiveState CheckObjective()
    {
        if (isObjectiveMainCardAlive && (mainCard == null || mainCard.isDead))
        {
            return ObjectiveState.Lose;
        }
        if (isObjectiveEnemyCardsDead && enemyCards.Where(ec => ec.isDead).Count() == enemyCards.Count())
        {
            return ObjectiveState.Win;
        }
        if (isObjectivePlayerCardsAlive && playerCards.Where(pc => pc.isDead).Count() == playerCards.Count())
        {
            return ObjectiveState.Lose;
        }
        return ObjectiveState.NotReached;
    }
    public enum ObjectiveState 
    {
        NotReached,
        Win,
        Lose
    }
}
