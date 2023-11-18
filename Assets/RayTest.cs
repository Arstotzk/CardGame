using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z));
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10000);
        //Debug.DrawLine(new Vector3(200, 200, 200), Vector3.zero, Color.red, 1f, false);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        foreach (var hit in raycastHits)
        {
            Debug.Log("Ray: " + ray);
        }
    }
}
