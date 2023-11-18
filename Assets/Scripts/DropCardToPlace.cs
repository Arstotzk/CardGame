using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCardToPlace : MonoBehaviour, IDropHandler
{
    public bool isMultiCard = false;
    public bool isEnemy = false;
    public bool isHand = false;
    public void OnDrop(PointerEventData eventData)
    {
        Card cardParam = eventData.pointerDrag.GetComponent<Card>();
        if (cardParam.isMoveable == true)
        {
            try
            {
                CardPerson card = eventData.pointerDrag.GetComponent<CardPerson>();
                if (card && (transform.childCount == 0 || isMultiCard)
                    && isEnemy == false && card.deployManager.Reinforcement >= card.reinforcement)
                {
                    if (card.deployManager.Reinforcement < 0)
                        return;
                    card.CurrentParent = transform;
                    if (!isHand)
                    {
                        card.SoundOnDeck.Play();
                        card.deployManager.Reinforcement -= card.reinforcement;
                    }
                }
            }
            catch
            {
                CardItem card = eventData.pointerDrag.GetComponent<CardItem>();
                if (card && (transform.childCount == 0 || isMultiCard))
                {
                    //card.CurrentParent = transform;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
    public void OnMouseEnter()
    {
        Debug.Log("DropCardMouseEnter");
    }
}
