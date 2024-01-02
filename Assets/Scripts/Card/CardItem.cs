using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardItem : Card
{
    public int health;
    public int attack;
    public CardPerson cardInteract;

    public TMP_Text HealthText;
    public TMP_Text AttackText;

    public override void Start()
    {
        base.Start();
        HealthText.text = health.ToString();
        AttackText.text = attack.ToString();
    }
    public override void Action()
    {
        isMoveable = false;
        cardInteract.health += health;
        cardInteract.attack += attack;
        var pos = transform.position;
        pos.z = -0.1f;
        transform.position = pos;
        sound.audioSourceSfx.Play();
        deployManager.Reinforcement -= reinforcement;
        Invoke("Delete", sound.audioSourceSfx.clip.length);
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
