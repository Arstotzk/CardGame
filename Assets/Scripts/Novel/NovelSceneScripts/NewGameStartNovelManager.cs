using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameStartNovelManager : NovelManager
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelMind("��� ���� ����� ������� � ��� ������, ��������� ��������� ��� ���."));
        scripts.Add(new NovelSay("���������", "��, �����, ������� ��� ����� �� ��������������?"));
        scripts.Add(new NovelSay("�����", "���� ��� ���������, ������."));
        scripts.Add(new NovelSay("���������", "��� ��� �� ������, � ��� �� ������. ����� � ������� � ����������."));
        scripts.Add(new NovelSay("�����", "���������, ��� ���� ���������. � ��� ���� � ����� ������� �������?"));
        scripts.Add(new NovelSay("���������", "��� ������� ��� ������, ����� ���������."));
        scripts.Add(new NovelSay("�����", "� � ����� ������� ������ ���, �� ����� ����."));
        scripts.Add(new NovelSay("�����", "�������� �� ������� ����� ������ ��� � � �������������� ���������."));
        scripts.Add(new NovelSay("���������", "� ������, ��� ���� ����� �����."));
        scripts.Add(new NovelMind("������ ��� ��������� �� ����� � �������."));
        scripts.Add(new NovelSay("�������", "�� ����� �������, ���� ������� �����."));
        scripts.Add(new NovelMind("������� �������� ���� ���� ��� �����������."));
        scripts.Add(new NovelMind("��������� ����� ���������� ����."));
        scripts.Add(new NovelSay("���������", "���� ���������. ������� � ����� ���� � ������. ���� ����� ������, � ����..."));
        scripts.Add(new NovelSay("***", "�. ��������� ������� ��?"));
        scripts.Add(new NovelMind("���������� �������� �����."));
        scripts.Add(new NovelMind("��� ���� ������� �������."));
        scripts.Add(new NovelSay("���������", "��������� ������."));
        scripts.Add(new NovelSay("������� �������", "��, ������, ������� ���, ������� ��� ������. ����� ������ � ������� �������, �������� ����."));
        scripts.Add(new NovelSay("���������", "������ ������. ������ ���������� � �������."));
        scripts.Add(new NovelSay("�������", "�� ����� ��. � ����� ����, �� �������� ���."));
        scripts.Add(new NovelSay("���������", "�����. ��������."));
        scripts.Add(new NovelMind("������� ������������, ��������� ������ ���� ����� � ������."));
        scripts.Add(new NovelMind("��������� �������� � ������� � ������ ����� ���� �������."));
        scripts.Add(new NovelSay("������� �������", "��-��. ������, �� ��� ���� ���������."));
        scripts.Add(new NovelSay("���������", "�� ���, ����������� ��� �� ���."));
        scripts.Add(new NovelSay("������� �������", "�� ��� � ������. ����� ����, �����."));
        scripts.Add(new NovelSay("������� �������", "��� ���� ����� ������. �� ��� ������ ���� �� ����� �������� ���� � ���� � ������ � ����� �� ����, � ��� ����."));
        scripts.Add(new NovelSay("���������", "����� � ��� ������."));
        scripts.Add(new NovelSay("������� �������", "�����, ���� ����� �� ���� ��� ���� �����, � �� ������ ����������. � � ���� �� ���� ������ ������."));
        scripts.Add(new NovelMind("��������� ����� � �������� � ������ �������� ����� � ������."));
        scripts.Add(new NovelMind("�� ������ ����� � ������� ����������� ����� ���. ������� � ���� �������."));
        scripts.Add(new NovelSay("���������", "�� ���, ���� ������ �������?"));
        scripts.Add(new NovelSay("��� ������", "�. ���?"));
        scripts.Add(new NovelMind("��� ����� ��������, ���������� �������� � ����������� � �� ��� ���� ������� ������."));
        scripts.Add(new NovelSay("��� ������", "���, ��������� ��? ����������. ������ ������ ������ � �� ���� � ������� �� ���������� ��� ��� ��� ���� ������."));
        scripts.Add(new NovelSay("���������", "������� ��������, �� ������� ��������, ������� ������� ��������."));
        scripts.Add(new NovelMind("��������� �������� �������� � ���������."));
        scripts.Add(new NovelSay("��� ������", "� �� �� ������� �������."));
        scripts.Add(new NovelMind("������ ��������� ����� ��������� ��� � ���� ��������� � �������� ������ �����."));
        scripts.Add(new NovelSay("��� ������", "��. ��� ��� ����?"));
        scripts.Add(new NovelSay("���������", "����� ���-�� �� �������. ����� ���������. ������� ��� �� �� � ��� � �����."));
        scripts.Add(new NovelSay("��� ������", "� ��� � �����."));
        scripts.Add(new NovelSay("���������", "�� ����, ������. ������ �� ����."));
        scripts.Add(new NovelMind("��������� � ����� �������� ������ ��������� � ����� ������ ��������� ���."));
        scripts.Add(new NovelMind("�������� ��� ���� ������ ��������� � ������ ���� ������."));
        scripts.Add(new NovelMind("��� ����������, ��� ���� ������� ����� ������ ������."));
        scripts.Add(new NovelMind("� ��� ��� ������� ��. ������."));
        scripts.Add(new NovelMind("�������������� ���������� �������� ���-�� ���������� ����� �� ����� ��������� ��������."));
        scripts.Add(new NovelMind("��������� ��������� �������� ���� ����� � ������ ������ ���."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���������� � �������."));
        scripts.Add(new NovelSay("��� ������", "*�������* ������� �� ����� ��� ����� �� ������. ����� ��� �������������."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���� ��������, ����� ��� ��� �� ��������."));
        scripts.Add(new NovelMind("� ��� ������������ �������� ����� ��� ������ ���� �������."));
        scripts.Add(new NovelMind("����� ����� ������������."));
        scripts.Add(new NovelMind("������� ���� � ������������� ������� �������� � ������� �����."));
        scripts.Add(new NovelSay("���������", "��������� �������."));

        PlayScript();
    }
}
