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
            FileStream file = File.Create(Application.persistentDataPath + "/" + saveFile);
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
            File.Copy(Application.persistentDataPath + "/" + saveFile, Application.persistentDataPath + "/" + "CurrentScene.dat", true);
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
            if (File.Exists(Application.persistentDataPath + "/" + saveFile))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + saveFile, FileMode.Open);
                saveData = (SaveData)bf.Deserialize(file);
                file.Close();
                Debug.Log("Game data loaded! SaveFile: " + saveFile);
            }
            else
                Debug.LogError("There is no save data! SaveFile: " + saveFile);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        return saveData;
    }
}

