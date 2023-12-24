using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelManager : MonoBehaviour
{
    public List<NovelScript> scripts;
    public int scriptNumber;
    public GameObject character;
    public GameObject mainText;
    // Start is called before the first frame update
    void Start()
    {
        scriptNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void PlayNextScript()
    {
        scriptNumber++;
        PlayScript();
    }
    public virtual void PlayScript()
    {

    }
}
