using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardStore : MonoBehaviour
{
    public List<Card> cards; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card GetCard(string prefabName)
    {
        return cards.Where(c => prefabName.Contains(c.name)).FirstOrDefault();
    }
}
