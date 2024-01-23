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

    public CardProperty cardProperty;

    public void FillCardInfo(Sprite sprite, string cardName, int health, int attack, int reinforcement, int initiative, CardProperty cardProperty) 
    {
        spriteRenderer.sprite = sprite;
        cardNameText.text = cardName;
        healthText.text = health.ToString();
        attackText.text = attack.ToString();
        reinforcementText.text = reinforcement.ToString();
        initiativeText.text = initiative.ToString();
        this.cardProperty.properties = cardProperty.properties;
        this.cardProperty.SetProperties();
    }

}
