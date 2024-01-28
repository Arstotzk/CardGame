using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueUI : MonoBehaviour
{
    public GameObject queueElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedrawQueueUI(Queue queue) 
    {
        foreach (var element in this.GetComponentsInChildren<QueueElementUI>())
        {
            Destroy(element.gameObject);
        }

        foreach (var queueAction in queue.queueActions)
        {
            var element = GameObject.Instantiate(queueElement);
            try
            {
                element.GetComponent<Image>().sprite = queueAction.GetSpriteUI();
            }
            catch (System.Exception ex)
            {
                Debug.LogWarning(ex.Message);
            }
            element.GetComponent<QueueElementUI>().place = queueAction.GetPlace();
            element.transform.SetParent(this.transform);
        }
    }
}
