using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public GameObject gameUI;
    public GameObject loseUI;
    public bool menuActive;
    public bool activeNovelPanel;
    public CardZoom cardZoom;
    public ChooseCard chooseCard;
    public DeckShow deckShow;
    void Start()
    {
        menuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            MenuTurn(!menuActive);
        }
        if (cardZoom != null && chooseCard != null && deckShow != null)
        {
            if (!cardZoom.GetCardIsZoomed() && !chooseCard.GetIsChoosing() && !deckShow.GetIsShowing() && !menu.activeSelf)
            {
                gameUI.SetActive(true);
            }
            else 
            {
                gameUI.SetActive(false);
            }
        }

        if (cardZoom != null && chooseCard == null && deckShow != null)
        {
            if (!cardZoom.GetCardIsZoomed() && !deckShow.GetIsShowing() && !menu.activeSelf)
            {
                gameUI.SetActive(true);
            }
            else
            {
                gameUI.SetActive(false);
            }
        }
    }

    public void MenuTurn(bool active) 
    {
        menuActive = active;
        menu.SetActive(active);
    }
    public void ShowLose()
    {
        loseUI.SetActive(true);
        MenuTurn(true);
    }
}
