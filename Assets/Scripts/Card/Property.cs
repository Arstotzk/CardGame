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
                description = "�������: ��������� ����� �� 1 ��� ��������� �����";
                name = "�������";
                isNegative = false;
                break;
            case Type.Clean:
                description = "��������: ������� ���������� ������� � �����";
                name = "��������";
                isNegative = false;
                break;
            case Type.Defence:
                description = "������: �������� ����� �� ����� ������ �� ������� ����";
                name = "������";
                isNegative = false;
                break;
            case Type.Healer:
                description = "������: ��������������� 1 �������� �������� ������ � ���� ��� ������������ �� ���� �� �����";
                name = "������";
                isNegative = false;
                break;
            case Type.Hook:
                description = "����: ������ ������� ����� � ������� ���� � ����������� � ��������";
                name = "����";
                isNegative = false;
                break;
            case Type.Poison:
                description = "��: � ������ ������ ���� �������� 1 ����. �������������. ����������";
                name = "��";
                isNegative = true;
                break;
            case Type.PoisonBlade:
                description = "�������� ������: ����������� �� �� ���������� ��� �����";
                name = "�������� ������";
                isNegative = false;
                break;
            case Type.Regeneration:
                description = "�����������: ��������������� 1 �������� � ������ ����";
                name = "�����������";
                isNegative = false;
                break;
            case Type.Sleep:
                description = "���: ���������� ���. ����������";
                name = "���";
                isNegative = true;
                break;
            case Type.Slowdown:
                description = "����������: ����������� ����� ����� �� 1 ���� �������� ������. �������������. ����������";
                name = "����������";
                isNegative = true;
                break;
            case Type.Speed:
                description = "��������: ����������� �� ���� ��� �� ������� ����� ��������";
                name = "��������";
                isNegative = false;
                break;
            case Type.Strength:
                description = "���� �����������: ��� ����� ����������� ���� ����� ������� �� ������� ���";
                name = "���� �����������";
                isNegative = false;
                break;
            case Type.Vampirism:
                description = "���������: ����� ����� ��������������� �������� ������ ���������� �����";
                name = "���������";
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
