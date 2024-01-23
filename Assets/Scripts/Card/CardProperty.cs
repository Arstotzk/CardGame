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
}
