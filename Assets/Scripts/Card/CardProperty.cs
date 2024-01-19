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
                    length.text = property.length.ToString();
                    break;
                case Property.Type.PoisonBlade:
                    propertySprite.sprite = poisonBladeSprite;
                    break;
                case Property.Type.Regeneration:
                    propertySprite.sprite = regenerationSprite;
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
}
