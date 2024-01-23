using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public CardZoomed cardZoomed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            CheckCard();
        }
    }

    private void CheckCard() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        foreach (var hit in raycastHits)
        {
            var card = hit.transform.gameObject.GetComponentInParent<CardPerson>();
            if (card != null)
            {
                cardZoomed.FillCardInfo(card.spriteRenderer.sprite, card.cardName, card.health, card.attack, card.reinforcement, card.initiative, card.cardProperty);
                Debug.Log("Card zoomed: " + card.name);            
            }
        }
    }
}
