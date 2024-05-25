using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menu;
    public GameObject novelPanel;
    public GameObject saves;
    public SaveSerializer saveSerializer;
    public bool menuActive;
    public bool activeNovelPanel;
    public CardZoom cardZoom;
    public ChooseCard chooseCard;
    public DeckShow deckShow;
    void Start()
    {
        saveSerializer = (SaveSerializer)GameObject.FindObjectOfType(typeof(SaveSerializer));
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
                novelPanel.SetActive(true);
            }
            else 
            {
                novelPanel.SetActive(false);
            }
        }
    }

    public void MenuTurn(bool active) 
    {
        menuActive = active;
        menu.SetActive(active);
        //novelPanel.SetActive(!active);
        SaveTurn(false);
    }

    public void SaveTurn(bool active)
    {
        saves.SetActive(active);
        if (active == true)
        {
            saves.GetComponentInChildren<SaveFilesUI>().RedrawSaveFilesUI(saveSerializer.GetSaveFiles());
        }
    }
}
