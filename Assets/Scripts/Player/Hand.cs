using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
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
    }
    public bool CheckPointerOnHand(bool _pointerEnter, bool _pointerExit) 
    {
        if (_pointerEnter == true) { return true; }
        return true;
    }

    public void OnMouseEnterHand()
    {
        Debug.Log("HandMouseEnter");
        pointerOnHand = true;
        isFinished = false;
    }
    public void OnMouseExitHand()
    {
        Debug.Log("HandMouseExit");
        pointerOnHand = false;
        isFinished = false;
        if (elapsedFrames == interpolationFramesCount)
        {
            elapsedFrames = elapsedFrames - 1;
        }
    }
}
