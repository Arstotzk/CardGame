using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QueueElementUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Place place;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("QueueElementUI Mouse enter");
        place.StartAttackShow();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("QueueElementUI Mouse exit");
        place.StopAttackShow();
    }
}
