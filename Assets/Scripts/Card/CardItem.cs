using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardItem : Card
{
    public int health;
    public int attack;
    public CardPerson cardInteract;

    public TMP_Text healthText;
    public TMP_Text attackText;

    public SpriteRenderer healthIcon;
    public SpriteRenderer attackIcon;

    public override void Start()
    {
        base.Start();
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        if (health == 0)
        {
            healthText.enabled = false;
            healthIcon.enabled = false;
        }
        if (attack == 0)
        {
            attackText.enabled = false;
            attackIcon.enabled = false;
        }

    }
    public override void Action()
    {
        isMoveable = false;
        cardInteract.health += health;
        cardInteract.attack += attack;
        if (cardProperty.IsHasProperty(Property.Type.Clean))
        {
            cardInteract.cardProperty.RemoveNegativeProperties();
        }
        sound.audioSourceSfx.Play();
        deployManager.Reinforcement -= reinforcement;
        Death();
    }
    public override void OnMouseUp()
    {
        base.OnMouseUp();
        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            var isActivate = false;
            foreach (var hit in raycastHits)
            {
                var activateTo = hit.transform.gameObject.GetComponentInParent<CardPerson>();
                if (activateTo != null)
                {
                    isActivate = true;
                    cardInteract = activateTo;
                    Action();
                }
            }
            if (isActivate == false)
            {
                deployManager.PutCardFromBufferToHand(this);
            }
        }
    }
}
