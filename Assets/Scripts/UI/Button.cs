using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioClip battleStart;
    public AudioClip battleEnd;
    public BattleManager bm;
    public MusicManager mm;
    private Animator animator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!bm.isBattleActive)
        {
            bm.BattleStart();
            //mm.PlayMusic();
            animator.Play("StartBattle");
            audioSource.clip = battleStart;
            audioSource.Play();
        }
    }
    public void EndBattle()
    {
        animator.Play("EndBattle");
        audioSource.clip = battleEnd;
        audioSource.Play();
    }
}
