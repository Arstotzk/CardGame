using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public GameObject hand;
    public Vector3 mainPosititon;
    public int interpolationFramesCount = 120; // Number of frames to completely interpolate between the 2 positions
    public int elapsedFrames = 0;
    public bool isFinished = false;
    public bool pointerOnHand = false;
    bool pointerEnter = false;
    bool pointerExit = false;
    public float interpolationRatio;
    public GameObject hand;
    private Vector3 positionApper = new Vector3(0, (float)0.6, 0);
    public SoundManager smSlavic;
    public void OnPointerEnter (PointerEventData eventData)
    {
         //Debug.Log("Work " + interpolationRatio);
        // oldPosititon = transform.position;
        //Vector3 newPos = new Vector3(0,1,0);
        //transform.position = oldPosititon + newPos;
        pointerOnHand = true;
        isFinished = false;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Work-Exit " + interpolationRatio);
        //oldPosititon = transform.position;
        //Vector3 newPos = new Vector3(0, -1, 0);
        //transform.position = oldPosititon + newPos;
        // float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //Vector3.Lerp(Vector3.up, Vector3.forward, interpolationRatio);
        //elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
        //isFinished = false;
        pointerOnHand = false;
        isFinished = false;
        if (elapsedFrames == interpolationFramesCount) 
        {
            elapsedFrames = elapsedFrames - 1;
        }
    }
    public void Update()
    {
        if(pointerOnHand == true && isFinished == false) 
        {
            //Debug.Log("Up");
            interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            Vector3 interpolatedPosition = Vector3.Lerp(mainPosititon, mainPosititon + positionApper, interpolationRatio);
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
            hand.transform.position = interpolatedPosition;
            if (elapsedFrames == interpolationFramesCount) 
            {
                isFinished = true;
            }
        }
        
        if (pointerOnHand == false)
        {
            //Debug.Log("down");
            interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            Vector3 interpolatedPosition = Vector3.Lerp(mainPosititon, mainPosititon + positionApper, interpolationRatio);
            if (interpolationRatio > 0)
            {
                if ((elapsedFrames - 1) % (interpolationFramesCount - 1) != 0)
                {
                    elapsedFrames = (elapsedFrames - 1) % (interpolationFramesCount - 1);
                }
                else 
                {
                    elapsedFrames = (elapsedFrames - 2) % (interpolationFramesCount - 1);
                }
            }
            hand.transform.position = interpolatedPosition;
        }
        
    }
    public void Start() 
    {
        mainPosititon = hand.transform.position;
        FillCardsSounds(GetComponentsInChildren<CardPerson>());
    }
    public bool CheckPointerOnHand(bool _pointerEnter, bool _pointerExit) 
    {
        if (_pointerEnter == true) { return true; }
        return true;
    }

    public void FillCardsSounds(CardPerson[] cards)
    {
        foreach (var card in cards)
        {
                if (!card.isUniqueAttack)
                    card.SoundOnAttack.clip = smSlavic.GetOnAttackSoundClip();
                card.SoundOnDeck.clip = smSlavic.GetOnDeckSoundClip();
                card.SoundOnDeath.clip = smSlavic.GetOnDieSoundClip();
        }
    }
}
