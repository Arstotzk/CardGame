using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public abstract class Card : MonoBehaviour
{
    Camera MainCamera;
    Vector3 offset;
    Vector3 oldPos;
    Vector3 resize = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 normalSize = new Vector3(1.5f, 1.5f, 1.5f);
    public Transform DefaultParent;
    public Transform CurrentParent;
    public int column;
    public int row;
    public Place _place;
    public Place place
    { 
        get => _place;
        set
        {
            if (_place != null && _place != value)
            {
                _place.isCursored = false;
            }
            _place = value;
        }
    }
    public int _reinforcement;
    public int reinforcement 
    {
        get 
        {
            if (isFromHand)
                return _reinforcement;

            int additionalValue = 0;
            if (cardProperty!= null && cardProperty.IsHasProperty(Property.Type.Speed))
                additionalValue = -1;
            if (_reinforcement + additionalValue < 0)
                return 0;
            return _reinforcement + additionalValue;
        }
        set
        {
            _reinforcement = value;
        }
    }
    public string cardName;

    public TMP_Text rceText;
    public TMP_Text cardNameText;

    public DeployManager deployManager;
    public BattleManager battleManager;

    public bool isMoveable;
    public bool isDead;
    public bool isEnemy;
    public bool isFromHand;

    public Animator animator;

    public CardSound sound;

    public CardProperty cardProperty;
    public virtual void Start()
    {
        sound = GetComponent<CardSound>();
        rceText.text = reinforcement.ToString();
        cardNameText.text = cardName;
        animator = GetComponent<Animator>();
        if (GetComponentInParent<Place>() != null)
        {
            place = GetComponentInParent<Place>();
        }
        cardProperty = GetComponent<CardProperty>();
    }

    public GameObject enterObject;
    void Awake ()
    {
        MainCamera = Camera.main;
    }
    public void Delete() 
    {
        //Добавить в сброс
        Destroy(gameObject);
    }
    public void Death()
    {
        animator.Play("Death");
        Invoke("Delete", 1f); //Переделать на сброс карты в стопку сброса
    }

    //Взяли карту
    public void OnMouseDown()
    {
        if (deployManager.Reinforcement >= reinforcement && isMoveable == true)
        {
            deployManager.isPlayerDrugCard = true;
            animator.Play("OnDragStart");
            var mousePos = Input.mousePosition;
            offset = transform.position - MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z + transform.position.z));
            oldPos = offset;
            transform.SetParent(DefaultParent);
            CurrentParent = transform.parent;
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.01f);

            //забрали карту из руки
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            foreach (var hit in raycastHits)
            {
                var dctPlace = hit.transform.gameObject.GetComponent<DropCardToPlace>();
                if (dctPlace != null)
                {
                    isFromHand = dctPlace.isHand;
                    dctPlace.CardRemove();
                }
            }
        }
    }
    //Положили карту
    public virtual void OnMouseUp()
    {
        if (deployManager.Reinforcement >= reinforcement && isMoveable == true)
        {
            Debug.Log("OnMouseUp");
            deployManager.isPlayerDrugCard = false;
            var posit = transform.position;
            posit.z = 0f;
            transform.position = posit;
            animator.Play("OnDragEnd");
        }
    }
    public virtual void OnMouseDrag()
    {
        if (deployManager.Reinforcement >= reinforcement && isMoveable == true)
        {
            var mousePos = Input.mousePosition;
            Vector3 newPos = MainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z + transform.position.z));
            Vector3 difference = newPos - oldPos;
            Quaternion target = Quaternion.Euler(difference.y * 15, -difference.x * 15, 0);
            transform.rotation = target;

            var zFixedPosition = newPos + offset;
            //zFixedPosition.z = -0.01f;
            transform.position = zFixedPosition;
            //Debug.Log("MouseDrag: " + newPos + "; " + offset);
            oldPos = newPos;
        }
    }
    public virtual void OnMouseEnter()
    {
        var hand = CurrentParent.GetComponentInChildren<Hand>();
        if (hand != null)
            hand.OnMouseEnter();
    }
    public virtual void OnMouseExit()
    {
        var hand = CurrentParent.GetComponent<Hand>();
        if (hand != null)
            hand.OnMouseExit();
    }
    public void SetToPlace(Place setPlace)
    {
        place = setPlace;
        var dctPlace = setPlace.GetComponent<DropCardToPlace>();
        //Для вражеской карты из руки
        animator.Play("Rotate");
        var enemyHand = this.GetComponentInParent<DropCardToPlace>();

        transform.SetParent(dctPlace.transform);
        CurrentParent = setPlace.transform;
        sound.audioSourcePerson.clip = sound.GetOnDeckSoundClip();
        sound.audioSourcePerson.Play();
        dctPlace.CardAdded(this);
        enemyHand.CardRemove();
    }
    public void PlayDieSfx()
    {
        sound.audioSourceSfx.Play();
    }

    public abstract void Action();
}
