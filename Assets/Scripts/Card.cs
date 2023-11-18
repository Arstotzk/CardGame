using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour
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

    public GameObject enterObject;
    void Awake ()
    {
        MainCamera = Camera.main;
    }
    public void OnBeginDrag()
    {
        if (deployManager.Reinforcement > 0 && isMoveable == true)
        {
            deployManager.isPlayerDrugCard = true;
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

    public virtual void OnDrag(PointerEventData eventData)
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

    public virtual void OnEndDrag()
    {
        if (isMoveable == true && deployManager.isPlayerDrugCard == true)
        {
            deployManager.isPlayerDrugCard = false;
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

    public void OnMouseDown()
    {
        var mousePos = Input.mousePosition;
        offset = transform.position - MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z + transform.position.z));
        oldPos = offset;
        transform.SetParent(DefaultParent);
        CurrentParent = transform.parent;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.001f);
        Debug.Log("MouseDown");
    }
    public void OnMouseUp()
    {
        RaycastHit hit;

        var mousePos = Input.mousePosition;
        Vector3 newPos = MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z + transform.position.z));
        if (Physics.Raycast(newPos + offset, -Vector3.up, out hit))
            print("Found an object - distance: " + hit.distance);

        Debug.Log("MouseUp");
    }
    public void OnMouseDrag()
    {
        var mousePos = Input.mousePosition;
        Vector3 newPos = MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z + transform.position.z));
        Vector3 difference = newPos - oldPos;
        Quaternion target = Quaternion.Euler(difference.y * 15, -difference.x * 15, 0);
        transform.rotation = target;

        transform.position = newPos + offset;
        //Debug.Log("MouseDrag: " + newPos + "; " + offset);
        oldPos = newPos;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        foreach (var hit in raycastHits)
        {
            Debug.Log("Ray");
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10000, Color.red);
        }
    //    if (Physics.RaycastAll(newPos + offset, -Vector3.up, out hit))
    //        print("Found an object - distance: " + hit.distance);
    }
    public void OnMouseEnter()
    {
        var hand = CurrentParent.GetComponentInChildren<Hand>();
        if (hand != null)
            hand.OnMouseEnter();
    }
    public void OnMouseExit()
    {
        var hand = CurrentParent.GetComponent<Hand>();
        if (hand != null)
            hand.OnMouseExit();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }



}
