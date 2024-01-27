using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Property
{
    public bool isLengthProperty;
    public int _length;
    public int length 
    {
        get => _length;
        set 
        {
            _length = value;
        }
    }
    private string _description;
    public string description
    {
        get => _description;
        set
        {
            _description = value;
        }
    }

    public Type type;
    public Property(Type _type)
    {
        type = _type;
        isLengthProperty = false;
        SetDescription();
    }
    public Property(Type _type, int _length)
    {
        type = _type;
        length = _length;
        isLengthProperty = true;
        SetDescription();
    }

    public void SetDescription()
    {
        switch (type)
        {
            case Type.Berserk:
                description = "Ѕерсерк: усиливает атаку на 1 при получении урона";
                break;
            case Type.Clean:
                description = "ќчищение: снимает негативные эффекты с карты";
                break;
            case Type.Defence:
                description = "«ащита: отражает атаку на карту позади на дальнем р€ду";
                break;
            case Type.Healer:
                description = "Ћекарь: восстанавливает 1 здоровье соседним картам в р€ду при выкладывании из руки на доску";
                break;
            case Type.Hook:
                description = " рюк: атакой цепл€ет карты в дальнем р€ду и передвигает в передний";
                break;
            case Type.Poison:
                description = "яд: в начале хода перед атакой получает 1 урон. Ќакапливаетс€. Ќегативный";
                break;
            case Type.PoisonBlade:
                description = "ядовитый клинок: накладывает €д на противника при атаке";
                break;
            case Type.Regeneration:
                description = "–егенераци€: восстанавливает 1 здоровь€ в начале хода";
                break;
            case Type.Sleep:
                description = "—он: пропускает ход. Ќегативный";
                break;
            case Type.Slowdown:
                description = "«амедление: перемещение карты стоит на 1 очко действий больше. Ќакапливаетс€. Ќегативный";
                break;
            case Type.Speed:
                description = "—корость: перемещение по полю бо€ не требует очков действий";
                break;
            case Type.Strength:
                description = "—ила богатырска€: при атаке отталкивает одну карту спереди на дальний р€д";
                break;
            case Type.Vampirism:
                description = "¬ампиризм: после атаки восстанавливает здоровье равное показателю атаки";
                break;
            default:
                break;
        }
    }

    public enum Type
    {
        Berserk,
        Clean,
        Defence,
        Healer,
        Hook,
        Poison,
        PoisonBlade,
        Regeneration,
        Sleep,
        Slowdown,
        Speed,
        Strength,
        Vampirism
    } 
}
