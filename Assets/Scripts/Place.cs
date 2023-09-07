using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
    public int column;
    public int row;
    public DeployManager deployManager;
    void Start()
    {
        deployManager = GameObject.Find("DeployManager").GetComponent<DeployManager>();
    }

    public void StartAttackShow()
    {
        particleSystem.Play();
    }
    public void StopAttackShow()
    {
        particleSystem.Stop();
    }

    public void OnMouseEnter()
    {
         //if (deployManager.isPlayerDrugCard)
            SetCollorSelect();
    }
    public void OnMouseExit()
    {
        //if (deployManager.isPlayerDrugCard)
            SetCollorUnselect();
    }

    public void SetCollorSelect()
    {
        GetComponent<Image>().color = new Color32(255, 255, 225, 100);
    }
    public void SetCollorUnselect()
    {
        GetComponent<Image>().color = new Color32(255, 255, 225, 0);
    }
}
