using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRoundStart : MonoBehaviour
{
    // Start is called before the first frame update
    public int numCards;
    void Start()
    {
        var deck = GetComponent<Deck>();
        deck.Init();
        for (var num = 0; num < numCards; num++)
            deck.GetRandomCardToHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
