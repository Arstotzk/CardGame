using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCardToPlace : MonoBehaviour, IDropHandler
{
    public bool isMultiCard = false;
    public bool isEnemy = false;
    public bool isHand = false;

    public Vector3 mainPosititon;
    public int interpolationFramesCount = 60; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public bool cardAdded = false;
    public float interpolationRatio;
    private Vector3 positionApper;

    public void OnDrop(PointerEventData eventData)
    {
        Card cardParam = eventData.pointerDrag.GetComponent<Card>();
        if (cardParam.isMoveable == true)
        {

            //ЧЗХ дичь полная зачем в трае проверка на объект cardPerson
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
                //ЧЗХ дичь полная
                CardItem card = eventData.pointerDrag.GetComponent<CardItem>();
                if (card && (transform.childCount == 0 || isMultiCard))
                {
                    //card.CurrentParent = transform;
                }
            }
        }
    }

    public void CardAdded() 
    {
        var card = GetComponentInChildren<Card>();
        cardAdded = true;
        mainPosititon = card.transform.position;
        positionApper = transform.position;
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

    public void Update()
    {
        if (cardAdded)
        {
            var card = GetComponentInChildren<Card>();
            interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            Vector3 interpolatedPosition = Vector3.Lerp(mainPosititon, positionApper, interpolationRatio);
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
            interpolatedPosition.z = card.transform.position.z;
            card.transform.position = interpolatedPosition;
            if (elapsedFrames == interpolationFramesCount)
            {
                cardAdded = false;
                elapsedFrames = 0;
                positionApper.z = card.transform.position.z;
                card.transform.position = positionApper;
            }
        }
    }
}
