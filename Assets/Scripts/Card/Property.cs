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
    public Type type;
    public Property(Type _type)
    {
        type = _type;
        isLengthProperty = false;
    }
    public Property(Type _type, int _length)
    {
        type = _type;
        length = _length;
        isLengthProperty = true;
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
