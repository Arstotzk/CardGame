using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public List<Place> attackPlaces;
    public bool isUniqueAttack = false;

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

    public float GetFutureActionTime() 
    {
        float actionTime = 0.0f;
        if (!futureIsDead)
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
                }
            }
            if (cardsImpact.Count > 0)
                actionTime += GetClipAttackLength();
            foreach (var cardImpact in cardsImpact)
            {
                float longestDeathSound = 0.0f;
                if (GetFutureIsDead(cardImpact))
                {
                    if(longestDeathSound < cardImpact.GetClipDeathLength())
                        longestDeathSound = cardImpact.GetClipDeathLength();
                }
                actionTime += longestDeathSound;
            }
        }
        return actionTime;
    }
    public List<Place> GetCurrentAttackPlaces() 
    {
        var places = new List<Place>();
        var attackLocations = attackPattern.GetAttackLocations();
        foreach (var attackLocation in attackLocations)
        {
            var rowLocation = attackLocation.Item1;
            var columnLocation = attackLocation.Item2;
            Place attackPlace = null;
            if (!isEnemy)
                attackPlace = battleManager.GetPlaceAt(-1 + columnLocation + column, -3 + rowLocation + row);
            else
                attackPlace = battleManager.GetPlaceAt(-1 + columnLocation + column, 1 + rowLocation + row);
            if(attackPlace != null)
                places.Add(attackPlace);
        }
        return places;
    }

    public void ShowAttackPlaces()
    {
        attackPlaces = GetCurrentAttackPlaces();
        foreach (var attackPlace in attackPlaces) 
        {
            if(attackPlace != null)
                attackPlace.StartAttackShow();
        }
    }
    public void StopShowAttackPlaces()
    {
        foreach (var attackPlace in attackPlaces)
        {
            if (attackPlace != null)
                attackPlace.StopAttackShow();
        }
        attackPlaces = new List<Place>();
    }

    public bool GetFutureIsDead(Card cardImpact)
    {
        cardImpact.futureHealth -= Attack;
        return cardImpact.futureIsDead;
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
    public void PlayHit()
    {
        SoundAttack.Play();
        foreach (var cardImpact in cardsImpact) 
        {
            Debug.Log("-health");
            Debug.Log(cardImpact.cardName);
            cardImpact.health -= Attack;
        }
    }
    public float GetClipDeathLength() 
    {
        return SoundOnDeath.clip.length;
    }

    public float GetClipAttackLength()
    {
        return SoundOnAttack.clip.length;
    }
    public override void OnMouseDrag()
    {
        base.OnMouseDrag();

        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            foreach (var hit in raycastHits)
            {
                var hitPlace = hit.transform.gameObject.GetComponent<Place>();
                if (hitPlace != null)
                {
                    place = hitPlace;
                    column = place.column;
                    row = place.row;
                    place.isCursored = true;
                } 
            }
        }

    }
    public override void OnEndDrag()
    {
        base.OnEndDrag();
        if (isMoveable == true && deployManager.isPlayerDrugCard == true)
        {
            StopShowAttackPlaces();
        }
    }

    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
        if (!deployManager.isPlayerDrugCard && place != null)
            ShowAttackPlaces();
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
        if (!deployManager.isPlayerDrugCard && place != null)
            StopShowAttackPlaces();
    }

}
