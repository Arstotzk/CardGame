using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
class column
{
    bool[] row;
}
public class CardPerson : Card
{
    public AttackPattern attackPattern;
    public GameObject attackPatternIcon;
    public List<CardPerson> cardsImpact;

    public override void Start()
    {
        base.Start();
        var pattern = attackPatternIcon.GetComponentsInChildren<Image>();
        foreach (var point in pattern) 
        {
            var coordinates = point.name.Split(".");
            var columnPattern = int.Parse(coordinates[0]);
            var rowPattern = int.Parse(coordinates[1]);
            if (attackPattern.rows[columnPattern - 1].row[rowPattern - 1] == true)
            {
                point.color = new Color32(150, 0, 0, 255);
            }
        }
    }
    public void Action()
    {
        if (!isDead)
        {
            cardsImpact = new List<CardPerson>();
            var attackLocations = attackPattern.GetAttackLocations();
            foreach (var attackLocation in attackLocations)
            {
                var rowLocation = attackLocation.Item1;
                var columnLocation = attackLocation.Item2;
                CardPerson cardImpact = null;
                if (!isEnemy)
                    cardImpact = battleManager.GetCardAt(-1 + columnLocation + column, -3 + rowLocation + row);
                else
                    cardImpact = battleManager.GetCardAt(-1 + columnLocation + column, 1 + rowLocation + row);

                if (cardImpact && ((isEnemy && !cardImpact.isEnemy) || (!isEnemy && cardImpact.isEnemy)))
                {
                    cardsImpact.Add(cardImpact);
                    Debug.Log(string.Format("Card attack action: {0}", cardImpact.cardName));
                    transform.SetParent(DefaultParent);
                    animator.Play("OnDragStart");
                    SoundOnAttack.Play();
                    Debug.Log(string.Format("SoundOnAttack time: {0}", SoundOnAttack.clip.length.ToString()));
                    Invoke("PlayAttackAnimation", SoundOnAttack.clip.length);
                }
            }
            Debug.Log(string.Format("Card action: {0}", cardName));
        }

    }
    public bool IsAnyToAction() 
    {
        var attackLocations = attackPattern.GetAttackLocations();
        foreach (var attackLocation in attackLocations)
        {
            var rowLocation = attackLocation.Item1;
            var columnLocation = attackLocation.Item2;
            CardPerson cardImpact = null;
            if (!isEnemy)
                cardImpact = battleManager.GetCardAt(-1 + columnLocation + column, -3 + rowLocation + row);
            else
                cardImpact = battleManager.GetCardAt(-1 + columnLocation + column, 1 + rowLocation + row);

            if (cardImpact && ((isEnemy && !cardImpact.isEnemy) || (!isEnemy && cardImpact.isEnemy)))
            {
                return true;
            }
        }
        return false;
    }
    public void PlayAttackAnimation()
    {
        Debug.Log("PlayAttackAnimation()");
        if (isEnemy)
            animator.Play("AttackEnemy");
        else
            animator.Play("Attack");
        Invoke("SetCurrentParent", GetClipLength("Attack"));
    }
    public void SetDefaultParent() 
    {
        transform.SetParent(DefaultParent);
    }
    public void SetCurrentParent()
    {
        transform.SetParent(CurrentParent);
    }

    public float GetClipLength(string name) 
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Equals(name))
                return clip.length;
        }
        return 0f;
    }
    public void PlayHitSound()
    {
        SoundAttack.Play();
        foreach (var cardImpact in cardsImpact) 
        {
            Debug.Log("-health");
            Debug.Log(cardImpact.cardName);
            cardImpact.health -= Attack;
        }
    }
}
