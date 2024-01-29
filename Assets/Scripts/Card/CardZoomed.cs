using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CardZoomed : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TMP_Text cardNameText;
    public TMP_Text healthText;
    public TMP_Text attackText;
    public TMP_Text reinforcementText;
    public TMP_Text initiativeText;

    public SpriteRenderer initiativeIcon;
    public SpriteRenderer attackIcon;
    public SpriteRenderer healthIcon;

    public CardProperty cardProperty;

    public void FillCardInfo(Sprite sprite, string cardName, int health, int attack, int reinforcement, int initiative, CardProperty cardProperty) 
    {
        spriteRenderer.sprite = sprite;
        cardNameText.text = cardName;
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        reinforcementText.text = reinforcement.ToString();
        initiativeText.text = initiative.ToString();
        initiativeText.enabled = true;
        initiativeIcon.enabled = true;
        healthText.enabled = true;
        healthIcon.enabled = true;
        attackText.enabled = true;
        attackIcon.enabled = true;
        this.cardProperty.properties = cardProperty.properties;
        this.cardProperty.SetProperties();
        this.cardProperty.SetPropertiesDescription();
    }

    public void FillCardInfo(Sprite sprite, string cardName, int health, int attack, int reinforcement, CardProperty cardProperty)
    {
        spriteRenderer.sprite = sprite;
        cardNameText.text = cardName;
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        reinforcementText.text = reinforcement.ToString();
        initiativeText.enabled = false;
        initiativeIcon.enabled = false;
        if (health == 0)
        {
            healthText.enabled = false;
            healthIcon.enabled = false;
        }
        else
        {
            healthText.enabled = true;
            healthIcon.enabled = true;
        }
        if (attack == 0)
        {
            attackText.enabled = false;
            attackIcon.enabled = false;
        }
        else
        {
            attackText.enabled = true;
            attackIcon.enabled = true;
        }
        this.cardProperty.properties = cardProperty.properties;
        this.cardProperty.SetProperties();
        this.cardProperty.SetPropertiesDescription();
    }
}
