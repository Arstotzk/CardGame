using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveSerializer : MonoBehaviour
{
    public bool Save(string saveFile, string sceneNameSystem, SceneType sceneType, List<string> cardsNameSystem, List<int> mainCardProperty)
    {
        try
        {
            var saveData = new SaveData();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + saveFile + ".dat");
            saveData.scene = sceneNameSystem;
            saveData.cards = cardsNameSystem;
            saveData.mainCardProperty = mainCardProperty;
            saveData.sceneType = sceneType;
            bf.Serialize(file, saveData);
            file.Close();
            Debug.Log("Game data saved");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            return false;
        }
    }

    public bool CreateCurrentSave(string saveFile) 
    {
        try
        {
            File.Copy(Application.persistentDataPath + "/" + saveFile + ".dat", Application.persistentDataPath + "/" + "CurrentScene.dat", true);
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
            return false;
        }
    }

    public SaveData Load(string saveFile)
    {
        SaveData saveData = new SaveData();
        try
        {
            if (File.Exists(Application.persistentDataPath + "/" + saveFile + ".dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + saveFile + ".dat", FileMode.Open);
                saveData = (SaveData)bf.Deserialize(file);
                file.Close();
                Debug.Log("Game data loaded! SaveFile: " + saveFile + ".dat");
            }
            else
                Debug.LogError("There is no save data! SaveFile: " + saveFile + ".dat");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        return saveData;
    }

    public List<SaveFile> GetSaveFiles()
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
        return saveFiles;
    }
}

