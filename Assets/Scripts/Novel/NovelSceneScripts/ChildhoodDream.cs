using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildhoodDream : NovelManager
{
    public AudioClip BeginMusic;

    public Sprite village;
    public Sprite villagePlace;
    public Sprite river;

    public Card cardChoose1_1;
    public Card cardChoose1_2;
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelMusic(BeginMusic));
        scripts.Add(new NovelMind("���� �������� ���� ������ �� �������."));
        scripts.Add(new NovelSay("���������", "������, ��� ����� ���� ������ �����? ��� �� ����� ��. � ���� ������� �� �����, �������."));
        scripts.Add(new NovelSay("���������", "����� ������� �������� � �������, ����� ����� ���� � ���� ������."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("����� ���������� �������� � �������."));
        scripts.Add(new NovelMind("���� �� ����� �� ��� ����� �� �����."));
        scripts.Add(new NovelMind("��������� ���������� � �������� �������."));
        scripts.Add(new NovelSay("���������", "��� ������ �� ��������. �� ���� ����� ������ �� ���������?"));
        scripts.Add(new NovelSay("��������", "��� ������. ��� �� � �������, �� ���������� �������, �� ����� ������ ������ ������ �� ��������."));
        scripts.Add(new NovelSay("���������", "�� � ����� ���. �� � �� ����."));
        scripts.Add(new NovelSay("��������", "�� ���� � ��� ��� ���������. ������ �������� ��������. �� ����� ����� � �������, �������� ���. �� ����� ������� ���� ����� ���, � ������ ���� � ������ ����."));
        scripts.Add(new NovelSay("���������", "��, ������� �� ����. ��������� � �� ������� �����."));
        scripts.Add(new NovelMind("��������� ������ � ����� �������� ����� � �� ���."));
        scripts.Add(new NovelSay("��� ������", "�����, �� ����� ��� � ������ � �������. � � ������ � ��� ��������. ��� ������ �� �� ���� ������������ ��� ����� ����. �������� ���� ��� �� ��������� ����� ��������."));
        scripts.Add(new NovelBackground(villagePlace));
        scripts.Add(new NovelMind("��������� ������ ���� � ���� ������� ����� ������ �� ������ ����."));
        scripts.Add(new NovelMind("����� ���� �� ��� �� ��� �������������� ������. ����� ��� ������ � �� ��������� �� ������ ������."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("����. � ������� ������ ������ ��������� ��������� � �������� � ��������."));
        scripts.Add(new NovelSay("��������", "������ ����. �� ��� ��� �������, ��� ����� ���������� � ���� ����� �������."));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelSay("���������", "�������� �� ����� � ��� �����. �� ����� ��� �����."));
        scripts.Add(new NovelSay("��������", "� ������ ������ � ��������� �������, ����� ��� �������� ��������� �����, ��� ���� �� ����������."));
        scripts.Add(new NovelSay("�������", "��������, ������� ��������� ������. ������ ���� ��� � �������."));
        scripts.Add(new NovelSay("���������", "��������� ���, �� ��� ��� �� ����. ��������� �� ������ �����, � �� ����� ������� �� ��������. ���������, �� ������� ����� �� ������ �������."));
        scripts.Add(new NovelStartScene("SecondVillageBattle", "��������� ������ ����� ������ �� �������", SceneType.battle));
        PlayScript();
    }
}
