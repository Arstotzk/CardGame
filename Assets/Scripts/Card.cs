using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Camera SecondCamera;
    Vector3 offset;
    Vector3 oldPos;
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
            futureHealth = value;
            _health = value;
            if (value <= 0)
            {
                HealthText.text = "0";
                SoundOnDeath.Play();
                //animator.Play("OnDrugStart");
                Invoke("Death", SoundOnDeath.clip.length); //Переделать на сброс карты в стопку сброса
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

    public int _futureHealth;
    public int futureHealth { 
        get => _futureHealth;
        set 
        {
            _futureHealth = value;
            if (value <= 0)
                futureIsDead = true;
        } 
    }
    public bool futureIsDead;
    public virtual void Start()
    {
        HealthText.text = health.ToString();
        AttackText.text = Attack.ToString();
        InitiativeText.text = Initiative.ToString();
        rceText.text = reinforcement.ToString();
        cardNameText.text = cardName;
        animator = GetComponent<Animator>();

        futureHealth = _health;
        futureIsDead = isDead;
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
            var mousePos = Input.mousePosition;
            mousePos.z = 10; // select distance = 10 units from the camera
            offset = MainCamera.ScreenToWorldPoint(mousePos);
            offset.z = 0;
            oldPos = offset;
            CurrentParent = transform.parent;
            transform.SetParent(DefaultParent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 newPos = MainCamera.ScreenToWorldPoint(mousePos);
            newPos.z = 0;
            Vector3 difference = newPos - offset;
            Quaternion target = Quaternion.Euler(difference.y * 10, -difference.x * 10, 0);
            transform.rotation = target;
            Debug.Log("mousePos:" + mousePos);
            Debug.Log("newPos:" + newPos);
            Debug.Log("eventData.position:" + eventData.position);
            //Дичь, переделать
            transform.position = transform.position + ((newPos - offset) * 10f);
            offset = newPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isMoveable == true)
        {
            Debug.Log("DragEnd");
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = target;
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
    public void Death()
    {
        animator.Play("Burning");
        Invoke("Delete", 0.5f); //Переделать на сброс карты в стопку сброса
    }

}
