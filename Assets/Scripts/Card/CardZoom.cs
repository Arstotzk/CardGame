using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public CardZoomed cardZoomed;

    private bool isCardZoomed;
    private bool isPlayedAnimation;

    public DeployManager deployManager;

    public bool isNovel = false;
    public bool GetCardIsZoomed()
    {
        return isCardZoomed;
    }
    void Start()
    {
        isCardZoomed = false;
        isPlayedAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayedAnimation && !isCardZoomed && Input.GetMouseButtonDown(1)) 
        {
            CheckCard();
        }

        if (!isPlayedAnimation && isCardZoomed && Input.GetMouseButtonDown(1)) 
        {
            GetComponent<Animator>().Play("ToTransparent");
            cardZoomed.GetComponent<Animator>().Play("EndZoom");
            if(!isNovel)
                deployManager.SetAllMovable(true);
            StartCoroutine(CardZoomedChange(0.8f, false));
        }
    }

    private void CheckCard() 
    {
        //TODO Перенести это в отдельный класс
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        CardPerson card = null;
        CardItem cardItem = null;
        DeckShowClick deckShowClick = null;
        foreach (var hit in raycastHits)
        {
            var cardPersonHit = hit.transform.gameObject.GetComponentInParent<CardPerson>();
            if(cardPersonHit != null)
                card = cardPersonHit;
            var cardItemHit = hit.transform.gameObject.GetComponentInParent<CardItem>();
            if (cardItemHit != null)
                cardItem = cardItemHit;
            var deckShowClickHit = hit.transform.gameObject.GetComponentInParent<DeckShowClick>();
            if (deckShowClickHit != null)
                deckShowClick = deckShowClickHit;
        }
        if (deckShowClick != null)
        {
            deckShowClick.DeckShow();
            return;
        }
        if (card != null && ((!card.isEnemy) || (card.isEnemy && !card.isFromHand)))
        {
            cardZoomed.FillCardInfo(card.spriteRenderer.sprite, card.cardName, card.health, card.attack, card.reinforcement, card.initiative, card.cardProperty, card.attackPattern);
            GetComponent<Animator>().Play("ToBlack");
            cardZoomed.GetComponent<Animator>().Play("BeginZoom");
            Debug.Log("Card zoomed: " + card.name);
            if (!isNovel)
                deployManager.SetAllMovable(false);
            StartCoroutine(CardZoomedChange(0.8f, true));
        }
        else if (cardItem != null && ((!card.isEnemy) || (card.isEnemy && !card.isFromHand)))
        {
            cardZoomed.FillCardInfo(cardItem.spriteRenderer.sprite, cardItem.cardName, cardItem.health, cardItem.attack, cardItem.reinforcement, cardItem.cardProperty);
            GetComponent<Animator>().Play("ToBlack");
            cardZoomed.GetComponent<Animator>().Play("BeginZoom");
            Debug.Log("Card zoomed: " + cardItem.name);
            if (!isNovel)
                deployManager.SetAllMovable(false);
            StartCoroutine(CardZoomedChange(0.8f, true));
        }
    }

    public IEnumerator CardZoomedChange(float seconds, bool value)
    {
        isPlayedAnimation = true;
        yield return new WaitForSeconds(seconds);
        isCardZoomed = value;
        isPlayedAnimation = false;
    }
}
