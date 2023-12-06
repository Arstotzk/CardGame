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
    public GameObject cardBuffer;
    public bool testParticle = false;
    public bool testPatricle2 = false;
    private bool _isCursored;
    public bool isCursored 
    { 
        get => _isCursored;
        set 
        { 
            _isCursored = value;
            CardPerson card = cardBuffer.GetComponentInChildren<CardPerson>();
            if (card != null && value == false)
                card.StopShowAttackPlaces();
            else if (card != null && value == true)
                card.ShowAttackPlaces();
            else if (card == null)
            {
                var cardOnPlace = this.GetComponentInChildren<CardPerson>();
                if (cardOnPlace != null)
                    cardOnPlace.StopShowAttackPlaces();
            }
        } 
    }
    void Start()
    {
        deployManager = GameObject.Find("DeployManager").GetComponent<DeployManager>();
        isCursored = false;
    }
    public void Update()
    {

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
        if (deployManager.isPlayerDrugCard)
        {
            SetCollorSelect();
            //isCursored = true;
        }
    }
    public void OnMouseExit()
    {
        if (deployManager.isPlayerDrugCard)
        {
            SetCollorUnselect();
        }
        isCursored = false;
    }

    public void SetCollorSelect()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 225, 100);
    }
    public void SetCollorUnselect()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 225, 0);
    }
}
