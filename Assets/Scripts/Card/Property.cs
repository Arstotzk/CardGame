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
                description = "�������: ��������� ����� �� 1 ��� ��������� �����";
                break;
            case Type.Clean:
                description = "��������: ������� ���������� ������� � �����";
                break;
            case Type.Defence:
                description = "������: �������� ����� �� ����� ������ �� ������� ����";
                break;
            case Type.Healer:
                description = "������: ��������������� 1 �������� �������� ������ � ���� ��� ������������ �� ���� �� �����";
                break;
            case Type.Hook:
                description = "����: ������ ������� ����� � ������� ���� � ����������� � ��������";
                break;
            case Type.Poison:
                description = "��: � ������ ���� ����� ������ �������� 1 ����. �������������. ����������";
                break;
            case Type.PoisonBlade:
                description = "�������� ������: ����������� �� �� ���������� ��� �����";
                break;
            case Type.Regeneration:
                description = "�����������: ��������������� 1 �������� � ������ ����";
                break;
            case Type.Sleep:
                description = "���: ���������� ���. ����������";
                break;
            case Type.Slowdown:
                description = "����������: ����������� ����� ����� �� 1 ���� �������� ������. �������������. ����������";
                break;
            case Type.Speed:
                description = "��������: ����������� �� ���� ��� �� ������� ����� ��������";
                break;
            case Type.Strength:
                description = "���� �����������: ��� ����� ����������� ���� ����� ������� �� ������� ���";
                break;
            case Type.Vampirism:
                description = "���������: ����� ����� ��������������� �������� ������ ���������� �����";
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
