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
    public Vector3[] mainPositions;
    public int interpolationFramesCount = 60; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public int[] elspsedFramesCards;
    public bool isCardChanged = false;
    public Card addedCard;
    public Card[] movedCards;
    public float interpolationRatio;
    private Vector3 positionApper;
    public Vector3 center;

    public float cardWidth = 1.5f;
    public float widthBetweenCards = 0.0f;

    public void Start()
    {
        center = transform.position;
    }
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

    public void CardAdded(Card card)
    {
        addedCard = card;
        isCardChanged = true;
        mainPosititon = card.transform.position;
        //positionApper = center;
        if (isMultiCard)
        {
            movedCards = GetNumberCards();
            elspsedFramesCards = new int[movedCards.Length];
            for (int i = 0; i < elspsedFramesCards.Length; i++) { elspsedFramesCards[i] = 0; }
            mainPositions = new Vector3[movedCards.Length];
            for (int i = 0; i < mainPositions.Length; i++)
            {
                mainPositions[i] = movedCards[i].transform.position;
            }
        }
        if (isHand == false && !card.isEnemy)
        {
            card.deployManager.Reinforcement -= card.reinforcement;
        }
    }
    public void CardRemove() 
    {
        if (isMultiCard)
        {
            isCardChanged = true;
            movedCards = GetNumberCards();
            elspsedFramesCards = new int[movedCards.Length];
            for (int i = 0; i < elspsedFramesCards.Length; i++) { elspsedFramesCards[i] = 0; }
            mainPositions = new Vector3[movedCards.Length];
            for (int i = 0; i < mainPositions.Length; i++)
            {
                mainPositions[i] = movedCards[i].transform.position;
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

    public void Update()
    {
        if (isCardChanged && isMultiCard == false)
        {
            MoveCard(addedCard);
        }
        if (isCardChanged && isMultiCard == true) 
        {
            int position = 0;
            foreach (var card in movedCards)
            {
                elspsedFramesCards[position] = MoveCard(card, position, movedCards.Length,
                    elspsedFramesCards[position], mainPositions[position]);
                position++;
            }
        }
    }
    public Card[] GetNumberCards(Card addedCard)
    {
        var cardsInHand = GetComponentsInChildren<Card>();
        Card[] cards = new Card[cardsInHand.Length + 1];
        cards[0] = addedCard;
        cardsInHand.CopyTo(cards, 1);
        var len = cards.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (cards[j].transform.position.x > cards[j + 1].transform.position.x)
                {
                    Swap(ref cards[j], ref cards[j + 1]);
                }
            }
        }
        return cards;
    }
    public Card[] GetNumberCards() 
    {
        var cards = GetComponentsInChildren<Card>();
        var len = cards.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (cards[j].transform.position.x > cards[j + 1].transform.position.x)
                {
                    Swap(ref cards[j], ref cards[j + 1]);
                }
            }
        }
        return cards;
    }
    //метод перестановки элементов
    private void Swap(ref Card card1, ref Card card2)
    {
        var temp = card1;
        card1 = card2;
        card2 = temp;
    }
    private void MoveCard(Card card)
    {
        Debug.Log("MoveCard");
        interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        Vector3 interpolatedPosition = Vector3.Lerp(mainPosititon, center, interpolationRatio);
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
        interpolatedPosition.z = card.transform.position.z;
        card.transform.position = interpolatedPosition;
        if (elapsedFrames == interpolationFramesCount)
        {
            isCardChanged = false;
            elapsedFrames = 0;
            center.z = card.transform.position.z;
            card.transform.position = center;
        }
    }
    private int MoveCard(Card card, int position, int cardsCount, int elapsedFrame, Vector3 mainPos)
    {
        Debug.Log("MoveCard");
        positionApper = GetNewCardPosition(position, cardsCount);
        interpolationRatio = (float)elapsedFrame / interpolationFramesCount;
        Vector3 interpolatedPosition = Vector3.Lerp(mainPos, positionApper, interpolationRatio);
        elapsedFrame = (elapsedFrame + 1) % (interpolationFramesCount + 1);
        interpolatedPosition.z = card.transform.position.z;
        card.transform.position = interpolatedPosition;
        if (elapsedFrame == interpolationFramesCount)
        {
            isCardChanged = false;
            elapsedFrame = 0;
            positionApper.z = card.transform.position.z;
            card.transform.position = positionApper;
        }
        return elapsedFrame;
    }
    private Vector3 GetNewCardPosition(int position, int cardsCount) 
    {
        var newPosition = transform.position;
        var hasCenterPosition = false;
        if (cardsCount % 2 == 1)
            hasCenterPosition = true;
        if (cardsCount == 1)
        {
            newPosition.x = center.x;
            return newPosition;
        }
        if (cardsCount % 2 == 1 && cardsCount / 2 == position)
        {
            newPosition.x = center.x;
            return newPosition;
        }
        else
        {
            if (hasCenterPosition == true)
            {
                var centerPosition = cardsCount / 2;
                newPosition.x = center.x + ((cardWidth + widthBetweenCards) * (-centerPosition + position));
            }
            else
            {
                var centerPosition = cardsCount / 2;
                newPosition.x = center.x + ((cardWidth + widthBetweenCards) * (-centerPosition + position)) + ((cardWidth + widthBetweenCards) * 0.5f);
            }
        }
        return newPosition;
    }

}
