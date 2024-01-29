using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Property
{
    public bool isLengthProperty;
    public bool isNegative;
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
        SetSettings();
    }
    public Property(Type _type, int _length)
    {
        type = _type;
        length = _length;
        isLengthProperty = true;
        SetSettings();
    }

    public void SetSettings()
    {
        switch (type)
        {
            case Type.Berserk:
                description = "Ѕерсерк: усиливает атаку на 1 при получении урона";
                isNegative = false;
                break;
            case Type.Clean:
                description = "ќчищение: снимает негативные эффекты с карты";
                isNegative = false;
                break;
            case Type.Defence:
                description = "«ащита: отражает атаку на карту позади на дальнем р€ду";
                isNegative = false;
                break;
            case Type.Healer:
                description = "Ћекарь: восстанавливает 1 здоровье соседним картам в р€ду при выкладывании из руки на доску";
                isNegative = false;
                break;
            case Type.Hook:
                description = " рюк: атакой цепл€ет карты в дальнем р€ду и передвигает в передний";
                isNegative = false;
                break;
            case Type.Poison:
                description = "яд: в начале хода перед атакой получает 1 урон. Ќакапливаетс€. Ќегативный";
                isNegative = true;
                break;
            case Type.PoisonBlade:
                description = "ядовитый клинок: накладывает €д на противника при атаке";
                isNegative = false;
                break;
            case Type.Regeneration:
                description = "–егенераци€: восстанавливает 1 здоровь€ в начале хода";
                isNegative = false;
                break;
            case Type.Sleep:
                description = "—он: пропускает ход. Ќегативный";
                isNegative = true;
                break;
            case Type.Slowdown:
                description = "«амедление: перемещение карты стоит на 1 очко действий больше. Ќакапливаетс€. Ќегативный";
                isNegative = true;
                break;
            case Type.Speed:
                description = "—корость: перемещение по полю бо€ не требует очков действий";
                isNegative = false;
                break;
            case Type.Strength:
                description = "—ила богатырска€: при атаке отталкивает одну карту спереди на дальний р€д";
                isNegative = false;
                break;
            case Type.Vampirism:
                description = "¬ампиризм: после атаки восстанавливает здоровье равное показателю атаки";
                isNegative = false;
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
