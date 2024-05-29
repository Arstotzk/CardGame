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
    public AttackPattern attackPattern;
    public GameObject attackPatternIcon;

    public void FillCardInfo(Sprite sprite, string cardName, int health, int attack, int reinforcement, int initiative, CardProperty cardProperty, AttackPattern attackPattern) 
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
        this.attackPattern = attackPattern;
        var pattern = attackPatternIcon.GetComponentsInChildren<SpriteRenderer>();
        foreach (var point in pattern) 
        {
            var coordinates = point.name.Split(".");
            var columnPattern = int.Parse(coordinates[0]);
            var rowPattern = int.Parse(coordinates[1]);
            if (attackPattern.rows[columnPattern - 1].row[rowPattern - 1] == true)
            {
                point.color = new Color32(200, 40, 40, 255);
            }
            else 
            {
                point.color = new Color32(220, 220, 220, 255);
            }
        }
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
