using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class NovelSaveSerializer : MonoBehaviour
{
    public float secondsLoadDelay = 0.05f;
    const string lastSave = "LastSave.dat";
    const string prefSave = "SaveFile";

    public GameObject novelManager;
    void Start()
    {
        var saveFile = PlayerPrefs.GetString(prefSave);
        StartCoroutine(LoadAndSet(secondsLoadDelay, saveFile));
    }
    private IEnumerator LoadAndSet(float seconds, string saveFile)
    {
        yield return new WaitForSeconds(seconds);
        if (File.Exists(Application.persistentDataPath + "/" + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFile, FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();
            var sceneName = saveData.scene;
            ActiveNovelScript(sceneName);
        }
    }

    private void ActiveNovelScript(string sceneName)
    {
        var novelManagers = novelManager.GetComponents<NovelManager>();
        novelManagers.Where(nm => nm.scriptName.Equals(sceneName)).FirstOrDefault().enabled = true;
    }

}
