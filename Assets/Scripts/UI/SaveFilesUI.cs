using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveFilesUI : MonoBehaviour
{
    // Start is called before the first frame update
    public SaveFile saveFile;

    public void RedrawSaveFilesUI(List<SaveFile> saveFiles)
    {
        foreach (var element in this.GetComponentsInChildren<SaveFile>())
        {
            Destroy(element.gameObject);
        }

        foreach (var save in saveFiles)
        {
            SaveFile element = GameObject.Instantiate(saveFile);
            try
            {
                element.nameSystem = save.nameSystem;
                element.nameShow = save.nameShow;
                element.GetComponentInChildren<TMP_Text>().text = save.nameShow;
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning(ex.Message);
            }
            element.transform.SetParent(this.transform);
        }
    }
}
