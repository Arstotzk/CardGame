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

    private string _name;
    public string name
    {
        get => _name;
        set
        {
            _name = value;
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
                description = "Берсерк: усиливает атаку на 1 при получении урона";
                name = "Берсерк";
                isNegative = false;
                break;
            case Type.Clean:
                description = "Очищение: снимает негативные эффекты с карты";
                name = "Очищение";
                isNegative = false;
                break;
            case Type.Defence:
                description = "Защита: отражает атаку на карту позади на дальнем ряду";
                name = "Защита";
                isNegative = false;
                break;
            case Type.Healer:
                description = "Лекарь: восстанавливает 1 здоровье соседним картам в ряду при выкладывании из руки на доску";
                name = "Лекарь";
                isNegative = false;
                break;
            case Type.Hook:
                description = "Крюк: атакой цепляет карты в дальнем ряду и передвигает в передний";
                name = "Крюк";
                isNegative = false;
                break;
            case Type.Poison:
                description = "Яд: в начале своего хода получает 1 урон. Накапливается. Негативный";
                name = "Яд";
                isNegative = true;
                break;
            case Type.PoisonBlade:
                description = "Ядовитый клинок: накладывает яд на противника при атаке";
                name = "Ядовитый клинок";
                isNegative = false;
                break;
            case Type.Regeneration:
                description = "Регенерация: восстанавливает 1 здоровья в начале хода";
                name = "Регенерация";
                isNegative = false;
                break;
            case Type.Sleep:
                description = "Сон: пропускает ход. Негативный";
                name = "Сон";
                isNegative = true;
                break;
            case Type.Slowdown:
                description = "Замедление: перемещение карты стоит на 1 очко действий больше. Накапливается. Негативный";
                name = "Замедление";
                isNegative = true;
                break;
            case Type.Speed:
                description = "Скорость: перемещение по полю боя не требует очков действий";
                name = "Скорость";
                isNegative = false;
                break;
            case Type.Strength:
                description = "Сила богатырская: при атаке отталкивает одну карту спереди на дальний ряд";
                name = "Сила богатырская";
                isNegative = false;
                break;
            case Type.Vampirism:
                description = "Вампиризм: после атаки восстанавливает здоровье равное показателю атаки";
                name = "Вампиризм";
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
