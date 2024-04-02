using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckShowClick : MonoBehaviour
{
    public DeckShow deckShow;

    public void DeckShow()
    {
        deckShow.Show(GetComponent<Deck>());
    }

}
