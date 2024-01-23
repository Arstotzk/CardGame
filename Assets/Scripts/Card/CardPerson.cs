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
    public bool isPropertyOnDeckUsed = false;

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
            //TODO убрать cardProperty!= null, когда обновлю все карты и добалю этот класс
            if (_health > value && cardProperty!= null && cardProperty.IsHasProperty(Property.Type.Berserk))
            {
                //TODO Добавить эффект или анимацию, что атака увеличилась
                attack++;
            }

            futureHealth = value;
            _health = value;
            if (value <= 0)
            {
                HealthText.text = "0";
                sound.audioSourcePerson.clip = sound.GetOnDieSoundClip();
                sound.audioSourceSfx.clip = sound.GetOnDieSfxSoundClip();
                sound.audioSourcePerson.Play();
                //animator.Play("OnDrugStart");
                Invoke("Death", sound.audioSourcePerson.clip.length); //Переделать на сброс карты в стопку сброса
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
    int _initiative;
    public int initiative;

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
        InitiativeText.text = initiative.ToString();

        futureHealth = _health;
        futureIsDead = isDead;

        //TODO Показывать схему атаки только при просмотре карты на правую кнопку мыши (на самой карте не показывать)
        /*
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
        */
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
            Attack(cardImpact);
        }
        AfterAction();
    }
    public void Attack(CardPerson cardImpact)
    {
        Debug.Log("");
        Debug.Log(cardImpact.cardName);
        if (cardImpact.IsDefended())
        {
            int addedRow = isEnemy ? 1 : -1;
            var card = battleManager.GetCardAt(column, row + addedRow);
            //TODO запускаем анимацию защиты
            Debug.Log("Defence card: " + cardImpact + " by: " + card);
        }
        else
            cardImpact.health -= attack;

        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Strength))
        {
            int addedRow = isEnemy ? 1 : -1;
            var card = battleManager.GetCardAt(column, row + addedRow);
            if (card != null && !card.isEnemy.Equals(isEnemy))
            {
                var cardBehind = battleManager.GetCardAt(column, row + (addedRow * 2));
                if (cardBehind == null)
                {
                    var place = battleManager.GetPlaceAt(column, row + (addedRow * 2));
                    var dctPlace = place.GetComponent<DropCardToPlace>();
                    dctPlace.CardAddedFromProperty(card);
                    battleManager.FillCardsArray();
                }
            }
        }

        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Hook))
        {
            int rowBack;
            int rowFront;
            if (isEnemy)
            {
                rowBack = 3;
                rowFront = 2;
            }
            else
            {
                rowBack = 0;
                rowFront = 1;
            }

            if (cardImpact.row == rowBack)
            {
                var cardFront = battleManager.GetCardAt(cardImpact.column, rowFront);
                if (cardFront == null)
                {
                    var place = battleManager.GetPlaceAt(cardImpact.column, rowFront);
                    var dctPlace = place.GetComponent<DropCardToPlace>();
                    dctPlace.CardAddedFromProperty(cardImpact);
                    battleManager.FillCardsArray();
                }
            }
        }
    }

    public bool IsDefended() 
    {
        CardPerson card = null;
        if(isEnemy)
            card = battleManager.GetCardAt(column, row + 1);
        else
            card = battleManager.GetCardAt(column, row - 1);

        if (card == null)
            return false;

        if (card.isEnemy != isEnemy)
            return false;

        if (card.cardProperty != null && card.cardProperty.IsHasProperty(Property.Type.Defence))
            return true;
        return false;
    }
    public float GetClipDeathLength() 
    {
        //Переделать нужно для прогнозирования, чтобы одна карта завершала действие, а другая начинала сразу после завершения
        return 3.5f;
    }

    public float GetClipAttackLength()
    {
        //Переделать
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

        if (deployManager.Reinforcement >= reinforcement && isMoveable == true)
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
                    //Не нравится, нужно по умному сделать нормально проверять что это место под карту\ничего\рука
                    if (plac != null)
                    {
                        plac.isCursored = false;
                        isMoveToPlace = true;
                        OnDeck();
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
    public void OnDeck() 
    {
        isFromHand = false;

        sound.audioSourcePerson.clip = sound.GetOnDeckSoundClip();
        sound.audioSourcePerson.Play();

        battleManager.FillCardsArray();

        if (cardProperty.IsHasProperty(Property.Type.Healer) && !isPropertyOnDeckUsed)
        {
            List<CardPerson> cardsImpact = new List<CardPerson>();
            CardPerson getedCard;
            getedCard = battleManager.GetCardAt(column + 1, row);
            if (getedCard != null)
                cardsImpact.Add(getedCard);
            getedCard = battleManager.GetCardAt(column - 1, row);
            if (getedCard != null)
                cardsImpact.Add(getedCard);
            foreach (var cardImpact in cardsImpact)
            {
                Debug.Log("Heal card: " + cardImpact.name);
                cardImpact.RegenerateHealth(1);
            }
        }

        isPropertyOnDeckUsed = true;
    }

    public void BeforeAction()
    {
        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Poison))
            PoisonHealth(1);
        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Regeneration))
            RegenerateHealth(1);
        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Slowdown))
            SlowdownCountDown();
    }
    public void AfterAction()
    {
        if (cardProperty != null && cardProperty.IsHasProperty(Property.Type.Vampirism))
            RegenerateHealth(attack);
    }

    public void SlowdownCountDown()
    {
        //TODO добавить эффект замедления (лучше наверное на получении эффекта)
        //или эффект того что счетчик понизился
        var property = cardProperty.GetProperty(Property.Type.Slowdown);
        property.length--;
        if (property.length <= 0)
            cardProperty.RemoveProperty(property);
        else
            cardProperty.SetProperties();
    }
    public void PoisonHealth(int value)
    {
        //TODO добавить эффект яда
        health -= value;
        var property = cardProperty.GetProperty(Property.Type.Poison);
        property.length--;
        if (property.length <= 0)
            cardProperty.RemoveProperty(property);
        else
            cardProperty.SetProperties();
    }

    public void RegenerateHealth(int value)
    {
        if (value <= 0)
            return;
        if (health < defaultHealth)
        {
            //TODO добавть эффект регенерации 
            if (health + value >= defaultHealth)
                health = defaultHealth;
            else
                health += value;
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
