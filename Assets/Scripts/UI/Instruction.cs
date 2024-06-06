using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public List<Sprite> instructionScreens;
    public GameObject instruction;

    private int screenNum = 0;
    // Start is called before the first frame update

    public void ShowInstuction()
    {
        screenNum = 0;
        instruction.SetActive(true);
        var insructionImage = instruction.GetComponent<Image>();
        insructionImage.sprite = instructionScreens[screenNum];
    }
    public void NextInstruction()
    {
        screenNum++;
        if (screenNum >= instructionScreens.Count)
        {
            DisableInstuctions();
            return;
        }
        var insructionImage = instruction.GetComponent<Image>();
        insructionImage.sprite = instructionScreens[screenNum];
    }

    public void PreviosInsruction()
    {
        screenNum--;
        if (screenNum < 0)
        {
            DisableInstuctions();
            return;
        }
        var insructionImage = instruction.GetComponent<Image>();
        insructionImage.sprite = instructionScreens[screenNum];
    }
    public void DisableInstuctions() 
    {
        instruction.SetActive(false);
    }
}
