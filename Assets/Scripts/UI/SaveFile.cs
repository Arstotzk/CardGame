using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveFile : MonoBehaviour, IPointerClickHandler
{ 
    // Start is called before the first frame update
    public string nameSystem;
    public string nameShow;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        File.Copy(nameSystem, Application.persistentDataPath + "/" + "CurrentScene.dat", true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(nameSystem, FileMode.Open);
        SaveData saveData = (SaveData)bf.Deserialize(file);
        file.Close();
        if (saveData.sceneType == SceneType.battle) 
            SceneManager.LoadScene("BattleScene");
        else if (saveData.sceneType == SceneType.novel)
            SceneManager.LoadScene("VisualNovelScene");
    }
}
