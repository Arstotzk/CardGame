using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
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

    public AudioSource SoundAttack;
    public AudioSource SoundGetDammage;

    public int _futureHealth;
    public int futureHealth
    {
        get => _futureHealth;
        set
        {
            _futureHealth = value;
            if (value <= 0)
                futureIsDead = true;
        }
    }
    public bool futureIsDead;

    private int defaultHealth;
    public int _health;
    public int health
    {
        get => _health;
        set
        {
            futureHealth = value;
            _health = value;
            if (value <= 0)
            {
                HealthText.text = "0";
                sound.audioSourcePerson.clip = sound.GetOnDieSoundClip();
                sound.audioSourcePerson.Play();
                //animator.Play("OnDrugStart");
                Invoke("Death", sound.audioSourcePerson.clip.length); //���������� �� ����� ����� � ������ ������
                isDead = true;
            }
            else
            {
                HealthText.text = value.ToString();
                if (value == defaultHealth)
                    HealthText.color = (new Color32(255, 255, 255, 255));
                else if (value < defaultHealth)
                    HealthText.color = (new Color32(245, 155, 155, 255));
                else if (value > defaultHealth)
                    HealthText.color = (new Color32(155, 245, 155, 255));
            }
        }
    }
    private int defaultAttack;
    public int _attack;
    public int attack
    {
        get => _attack;
        set 
        {
            _attack = value;
            AttackText.text = value.ToString();

            if (value == defaultAttack)
                AttackText.color = (new Color32(255, 255, 255, 255));
            else if (value < defaultAttack)
                AttackText.color = (new Color32(245, 155, 155, 255));
            else if (value > defaultAttack)
                AttackText.color = (new Color32(155, 245, 155, 255));
        }
    }
    public int Initiative;

    public TMP_Text HealthText;
    public TMP_Text AttackText;
    public TMP_Text InitiativeText;

    public override void Start()
    {
        base.Start();
        HealthText.text = health.ToString();
        AttackText.text = attack.ToString();
        defaultHealth = health;
        defaultAttack = attack;
        InitiativeText.text = Initiative.ToString();

        futureHealth = _health;
        futureIsDead = isDead;

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
    public override void Action()
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
                    Debug.Log(string.Format("Card attack action: {0}", cardImpact.cardName));
                    cardsImpact.Add(cardImpact);
                }
            }
            if (cardsImpact.Count > 0)
            {
                //transform.SetParent(DefaultParent);
                animator.Play("OnDragStart");
                sound.audioSourcePerson.clip = sound.GetOnAttackSoundClip();
                sound.audioSourcePerson.Play();
                Debug.Log(string.Format("SoundOnAttack time: {0}", sound.audioSourcePerson.clip.length.ToString()));
                Invoke("PlayAttackAnimation", sound.audioSourcePerson.clip.length);
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

    public bool GetFutureIsDead(CardPerson cardImpact)
    {
        cardImpact.futureHealth -= attack;
        return cardImpact.futureIsDead;
    }
    public void PlayAttackAnimation()
    {
        Debug.Log("PlayAttackAnimation() " + cardName);
        if (isEnemy)
            animator.Play("AttackEnemy");
        else
            animator.Play("Attack");
        //Invoke("SetCurrentParent", GetClipLength("Attack"));
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
            cardImpact.health -= attack;
        }
    }
    public float GetClipDeathLength() 
    {
        //���������� ����� ��� ���������������, ����� ���� ����� ��������� ��������, � ������ �������� ����� ����� ����������
        return 3.5f;
    }

    public float GetClipAttackLength()
    {
        //����������
        return 3.5f;
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
    public override void OnMouseUp()
    {
        base.OnMouseUp();

        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            var isMoveToPlace = false;
            foreach (var hit in raycastHits)
            {
                var dctPlace = hit.transform.gameObject.GetComponent<DropCardToPlace>();
                if (dctPlace != null)
                {
                    CurrentParent = hit.transform;
                    transform.SetParent(CurrentParent);
                    dctPlace.CardAdded(this);
                    var plac = hit.transform.gameObject.GetComponent<Place>();
                    //�� ��������, ����� �� ������ ������� ��������� ��������� ��� ��� ����� ��� �����\������\����
                    if (plac != null)
                    {
                        plac.isCursored = false;
                        isMoveToPlace = true;
                        sound.audioSourcePerson.clip = sound.GetOnDeckSoundClip();
                        sound.audioSourcePerson.Play();
                    }
                }
            }
            if (isMoveToPlace == false)
            {
                place = null;
                deployManager.PutCardFromBufferToHand(this);
            }
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
