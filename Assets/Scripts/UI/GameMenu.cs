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
    public bool menuActive;
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
            DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/");
            var saveFiles = new List<SaveFile>();
            foreach (var file in dir.GetFiles())
            {
                if (file.Name != "CurrentScene.dat" && file.Extension == ".dat")
                {
                    var save = new SaveFile();
                    save.nameSystem = file.FullName;
                    save.nameShow = Path.GetFileNameWithoutExtension(file.Name) + " " + file.CreationTime.ToString("dd.MM.yyyy HH:mm:ss");
                    saveFiles.Add(save);
                }
            }
            saves.GetComponentInChildren<SaveFilesUI>().RedrawSaveFilesUI(saveFiles);
        }
    }
}
