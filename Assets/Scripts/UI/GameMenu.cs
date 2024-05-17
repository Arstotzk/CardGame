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
    public GameObject saves;
    public SaveSerializer saveSerializer;
    public bool menuActive;
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
    }

    public void MenuTurn(bool active) 
    {
        menuActive = active;
        menu.SetActive(active);
        gameUI.SetActive(!active);
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
