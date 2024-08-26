using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadToVillage : NovelManager
{
    public AudioClip BeginMusic;
    public AudioClip OutOfBreathSound;

    public Sprite village;
    public Sprite villagePlace;
    public Sprite river;

    public Card cardChoose1_1;
    public Card cardChoose1_2;
    public Card cardChoose2_1;
    public Card cardChoose2_2;
    void Start()
    {
        Debug.Log("RoadToVillage: " + scriptNumber);
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelSound(OutOfBreathSound));
        scripts.Add(new NovelMind("����� ������ ����� � ������� � ���������� � ���� ������� ��� ������� ������."));
        scripts.Add(new NovelSay("��� ������", "�� � ����� � ���� �������. ����� ������. ������ �����������, � �� � ������ ����� ���������."));
        scripts.Add(new NovelSay("���������", "��� �� ��� �� ������ ���������. �� ��� �� ��������, �� �� ��� ����� ��� ��������, ����� ������� � ������."));
        scripts.Add(new NovelSound(null));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMusic(BeginMusic));
        scripts.Add(new NovelMind("���� ����� �������� �� �������."));
        scripts.Add(new NovelMind("�� ����� � ������� �� ����������� ������� �������."));
        scripts.Add(new NovelSay("������� �������", "�� ������, ����� �� ���. ������ ��������� � ���� ��� ����? � �� ���� �� �����."));
        scripts.Add(new NovelSay("���������", "� ����� ��� ���������. ���� ������� � ��������, �� ������ � ���� ����."));
        scripts.Add(new NovelSay("������� �������", "� ��� ��������� ��?"));
        scripts.Add(new NovelSay("��� ������", "����. � �������� ��� ���������."));
        scripts.Add(new NovelMind("��� ������� ����������� ��� ����� �� �������� �������."));
        scripts.Add(new NovelSay("��������", "������ ������. � ��? ������� ���������, �������� �������."));
        scripts.Add(new NovelSay("���������", "��, ��������, �� � ������� �������."));
        scripts.Add(new NovelSay("��������", "� ��� �� ����� �������� � ����� ����� �������?"));
        scripts.Add(new NovelSay("���������", "�������� �� ������ ���� �������� ��������� �������. ���� �� ���������� ��� ������ ����������. ���� ���."));
        scripts.Add(new NovelSay("��������", "�� �� �������� ��� �� ��������. ��� �� ��� ��� ������?"));
        scripts.Add(new NovelSay("���������", "� ���� �� �������, �� ��� ���� �������� ���-�� ������."));
        scripts.Add(new NovelSay("���������", "����� ������� ���� ����������� � ���������� ��."));
        scripts.Add(new NovelSay("��������", "��������� ��������, ������ ��� �������."));
        scripts.Add(new NovelBackground(villagePlace));
        scripts.Add(new NovelMind("������ ��������� ����� ��� ������ ������� ��������� �� ������� �������."));
        scripts.Add(new NovelSay("�����������", "� ��� ��� ��� ���� �������?"));
        scripts.Add(new NovelSay("�����������", "�������� ���-�� ���������."));
        scripts.Add(new NovelSay("�����������", "� ���� ��� �� � ��������, � ��� ���������� ��������� ���������."));
        scripts.Add(new NovelMind("�� ����������������� ������� ����� �������� � ���������."));
        scripts.Add(new NovelSay("��������", "����� ���� ������."));
        scripts.Add(new NovelMind("������ ����� �������."));
        scripts.Add(new NovelSay("��������", "���� ����������� �� ���� �������. ��������� � �������� ���������� ���������� �� ������."));
        scripts.Add(new NovelSay("�����������", "����� � ���?"));
        scripts.Add(new NovelSay("�����������", "����� �� ����� ����."));
        scripts.Add(new NovelSay("�����������", "��� ��� �������?"));
        scripts.Add(new NovelSay("��������", "��� ��� � � ������ �� ����������, �� ������� ����� ����������, �� ��������� ���� ����� ��������."));
        scripts.Add(new NovelSay("���������", "��, ������������� ���� ���������, �� ��� �� ����� ������� ����."));
        scripts.Add(new NovelSay("���������", "������ �� ����� ����� �������� ������."));
        scripts.Add(new NovelSay("���������", "����� ������� ���������� ������� ����� � ����� �������, ����������. ��� ������?"));
        scripts.Add(new NovelSay("�������", "� ���� ���� ������ ������� ����!"));
        scripts.Add(new NovelSay("����������� �����", "� �����, � ������� ��� ��������� ����� ����."));
        scripts.Add(new NovelSay("�������", "��, � ����������� � ��������� ����� ����."));
        scripts.Add(new NovelMind("��������� ������ ����� � ������� � ������� ��� ������."));
        scripts.Add(new NovelSay("���������", "������ ��� ������ ���. ����� �� �������� ������ �� ���������, ��� ������ ����������."));
        scripts.Add(new NovelSay("����������� �����", "������� ������� �����!"));
        scripts.Add(new NovelMind("������� � ������ ������ ���� � ������ �������."));
        scripts.Add(new NovelSay("���������", "���� �������� �������, � ����������� ��� ��� ����� ������� �� ���� �������."));
        scripts.Add(new NovelSay("���������", "������� ��� ���������� ������������ � ������� ��� ����� �����."));
        scripts.Add(new NovelSay("���������", "� ������� ��� ���� ��� �� ��� ������ � �������, �� � ���������� ��� ����� ����� ��� �������."));
        scripts.Add(new NovelSay("���������", "��� �� ��� ���������� ������ �� ���, ��� ������������ ������������ ������."));
        scripts.Add(new NovelSay("��������", "� ��������� � ��� ������� �� ������� � ���� ����� ������� ����� ������ ����� ����������."));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelMind("���� ��� �����������, ��������� ������ �� ������� �� �������."));
        scripts.Add(new NovelChooseCard(cardChoose2_1, cardChoose2_2));
        scripts.Add(new NovelSay("���������", "���������, ��� ����� �������, ������������ ������ � ��������."));
        scripts.Add(new NovelSay("���������", "�� ��������� ������� ������ ������ �������."));
        scripts.Add(new NovelSay("���������", "��� ��� ���������� ����������."));
        scripts.Add(new NovelSay("�������", "����, ��� ����!"));
        scripts.Add(new NovelMind("������ �� �������, ��������� ������������ �������."));
        scripts.Add(new NovelMind("����� ����������� �������� ������."));
        scripts.Add(new NovelSay("���������", "���� ����, �� ����������. ��� �� �� �����?"));
        scripts.Add(new NovelSay("�������", "������ �������� ����� ��������� � ������ ��� ��� ���� � ������, �� ������. � ���� ������ ����� �����."));
        scripts.Add(new NovelSay("���������", "��� ��� �� ����� �������, ��������� � �����, �� ������ ������ ������� ��� � ������ � ������� ���������."));
        scripts.Add(new NovelSay("���������", "��������� ��������� �������, ��� ����� ������� ��� � ������ �������."));
        scripts.Add(new NovelSay("���������", "� �� ����� ������� ��������� �� � �������� ������� �� ����� ��������."));
        scripts.Add(new NovelSay("���������", "������� ����������� �������!"));
        scripts.Add(new NovelSay("�����������", "���! �����!"));
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelMind("����� ���������� ����� �� ������� ���, ����� �� �� ���� ����� � �������� ������."));
        scripts.Add(new NovelMind("���� ���������� �� ��������� ����� � ������� � �������� ���."));
        scripts.Add(new NovelMind("���� ��� ������ ��������� ������ �� ������������� �������� �����. ��������� ������ ��� ���������."));
        scripts.Add(new NovelStartScene("FirstVillageBattle", "������ ����� ������ �� �������", SceneType.battle));
        PlayScript();
    }
}
