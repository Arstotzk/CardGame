using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CardProperty : MonoBehaviour
{
    public Sprite berserkSprite;
    public Sprite cleanSprite;
    public Sprite defenceSprite;
    public Sprite healerSprite;
    public Sprite hookSprite;
    public Sprite poisonSprite;
    public Sprite poisonBladeSprite;
    public Sprite regenerationSprite;
    public Sprite sleepSprite;
    public Sprite slowdownSprite;
    public Sprite speedSprite;
    public Sprite strengthSprite;
    public Sprite vampirismSprite;

    public List<Property> properties;
    public List<GameObject> propertyObjects;
    public List<GameObject> propertyDescriptions;

    // Start is called before the first frame update
    void Start()
    {
        SetProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProperties()
    {
        var propertyNum = 0;
        foreach (var property in properties)
        {
            var propertySprite = propertyObjects[propertyNum].GetComponent<SpriteRenderer>();
            var length = propertyObjects[propertyNum].GetComponentInChildren<TextMeshPro>();
            switch (property.type)
            {
                case Property.Type.Berserk:
                    propertySprite.sprite = berserkSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Clean:
                    propertySprite.sprite = cleanSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Defence:
                    propertySprite.sprite = defenceSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Healer:
                    propertySprite.sprite = healerSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Hook:
                    propertySprite.sprite = hookSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Poison:
                    propertySprite.sprite = poisonSprite;
                    length.text = property.length.ToString();
                    break;
                case Property.Type.PoisonBlade:
                    propertySprite.sprite = poisonBladeSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Regeneration:
                    propertySprite.sprite = regenerationSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Sleep:
                    propertySprite.sprite = sleepSprite;
                    length.text = property.length.ToString();
                    break;
                case Property.Type.Slowdown:
                    propertySprite.sprite = slowdownSprite;
                    length.text = property.length.ToString();
                    break;
                case Property.Type.Speed:
                    propertySprite.sprite = speedSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Strength:
                    propertySprite.sprite = strengthSprite;
                    length.text = string.Empty;
                    break;
                case Property.Type.Vampirism:
                    propertySprite.sprite = vampirismSprite;
                    length.text = string.Empty;
                    break;
                default:
                    break;
            }
            propertyNum++;
        }

        for (; propertyNum < propertyObjects.Count; propertyNum++)
        {
            var propertySprite = propertyObjects[propertyNum].GetComponent<SpriteRenderer>();
            propertySprite.sprite = null;
            var text = propertyObjects[propertyNum].GetComponentInChildren<TextMeshPro>();
            text.text = string.Empty;
        }
    }

    public void SetPropertiesDescription()
    {
        var propertyNum = 0;
        foreach (var property in properties)
        {
            var propertySprite = propertyDescriptions[propertyNum].GetComponent<SpriteRenderer>();
            var descriprion = propertyDescriptions[propertyNum].GetComponentInChildren<TextMeshPro>();
            //TODO Сделать чтобы через при создании через инспектор описание генерилось сразу
            if (property.description == null)
                property.SetSettings();
            descriprion.text = property.description + (property.isLengthProperty ? " x" + property.length : "" );
            switch (property.type)
            {
                case Property.Type.Berserk:
                    propertySprite.sprite = berserkSprite;
                    break;
                case Property.Type.Clean:
                    propertySprite.sprite = cleanSprite;
                    break;
                case Property.Type.Defence:
                    propertySprite.sprite = defenceSprite;
                    break;
                case Property.Type.Healer:
                    propertySprite.sprite = healerSprite;
                    break;
                case Property.Type.Hook:
                    propertySprite.sprite = hookSprite;
                    break;
                case Property.Type.Poison:
                    propertySprite.sprite = poisonSprite;
                    break;
                case Property.Type.PoisonBlade:
                    propertySprite.sprite = poisonBladeSprite;
                    break;
                case Property.Type.Regeneration:
                    propertySprite.sprite = regenerationSprite;
                    break;
                case Property.Type.Sleep:
                    propertySprite.sprite = sleepSprite;
                    break;
                case Property.Type.Slowdown:
                    propertySprite.sprite = slowdownSprite;
                    break;
                case Property.Type.Speed:
                    propertySprite.sprite = speedSprite;
                    break;
                case Property.Type.Strength:
                    propertySprite.sprite = strengthSprite;
                    break;
                case Property.Type.Vampirism:
                    propertySprite.sprite = vampirismSprite;
                    break;
                default:
                    break;
            }
            propertyNum++;
        }

        for (; propertyNum < propertyObjects.Count; propertyNum++)
        {
            var propertySprite = propertyDescriptions[propertyNum].GetComponent<SpriteRenderer>();
            propertySprite.sprite = null;
            var text = propertyDescriptions[propertyNum].GetComponentInChildren<TextMeshPro>();
            text.text = string.Empty;
        }
    }

    public bool IsHasProperty(Property.Type type)
    {
        return properties.Where(p => p.type.Equals(type)).Any();
    }
    public Property GetProperty(Property.Type type)
    {
        return properties.Where(p => p.type.Equals(type)).FirstOrDefault();
    }
    public void RemoveProperty(Property property) 
    {
        properties.Remove(property);
        SetProperties();
    }

    public void SetProperty(Property.Type type) 
    {
        properties.Add(new Property(type));
    }

    public void SetProperty(Property.Type type, int length)
    {
        var property = GetProperty(type);
        if (property != null)
        {
            property.length += length;
            SetProperties();
            return;
        }
        else
        {
            properties.Add(new Property(type, length));
            SetProperties();
        }
    }

    public void RemoveNegativeProperties()
    {
        var propertyList = properties.Where(p => p.isNegative == true).ToList();
        foreach (var property in propertyList)
        {
            RemoveProperty(property);
        }
        SetProperties();
    }
}
