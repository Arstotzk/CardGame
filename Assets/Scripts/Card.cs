using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    Vector3 resize = new Vector3(1.3f, 1.3f, 1.3f);
    public Transform DefaultParent;
    public Transform CurrentParent;
    public int column;
    public int row;

    public int _health;
    public int health
    { 
        get => _health;
        set 
        {
            _health = value;
            if (value <= 0)
            {
                HealthText.text = "0";
                SoundOnDeath.Play();
                animator.Play("Death");
                Invoke("Delete", 3); //Переделать на сброс карты в стопку сброса
                isDead = true;
            }
            else 
            {
                HealthText.text = value.ToString();
            }
        } 
    }
    public int Attack;
    public int Initiative;
    public int reinforcement;
    public string cardName;

    public TMP_Text HealthText;
    public TMP_Text AttackText;
    public TMP_Text InitiativeText;
    public TMP_Text rceText;
    public TMP_Text cardNameText;

    public DeployManager deployManager;
    public BattleManager battleManager;

    public bool isMoveable;
    public bool isDead;
    public bool isEnemy;

    public Animator animator;

    public AudioSource SoundOnDeck;
    public AudioSource SoundOnAttack;
    public AudioSource SoundOnDeath;

    public AudioSource SoundAttack;
    public AudioSource SoundGetDammage;
    public virtual void Start()
    {
        HealthText.text = health.ToString();
        AttackText.text = Attack.ToString();
        InitiativeText.text = Initiative.ToString();
        rceText.text = reinforcement.ToString();
        cardNameText.text = cardName;
        animator = GetComponent<Animator>();
    }
    void Awake ()
    {
        MainCamera = Camera.allCameras[0]; //TODO Костыль, перописать по нормальному
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            //transform.localScale = resize;
            animator.Play("OnDragStart");
            offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
            CurrentParent = transform.parent;
            transform.SetParent(DefaultParent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
            transform.position = newPos + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isMoveable == true)
        {
            Debug.Log("DragEnd");
            animator.Play("OnDragEnd");
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.SetParent(CurrentParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
    public void Delete() 
    {
        Destroy(gameObject);
    }

}
