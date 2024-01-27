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
            deployManager.SetAllMovable(true);
            StartCoroutine(CardZoomedChange(0.8f, false));
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
                GetComponent<Animator>().Play("ToBlack");
                cardZoomed.GetComponent<Animator>().Play("BeginZoom");
                Debug.Log("Card zoomed: " + card.name);
                deployManager.SetAllMovable(false);
                StartCoroutine(CardZoomedChange(0.8f, true));
            }
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
