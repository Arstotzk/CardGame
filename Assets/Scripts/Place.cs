using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
    public int column;
    public int row;
    void Start()
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
}
