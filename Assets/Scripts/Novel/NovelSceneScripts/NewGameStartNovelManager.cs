using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameStartNovelManager : NovelManager
{
    public AudioClip BeginMusic;
    public AudioClip LizardMusic;
    public AudioClip HorseSound;
    public AudioClip ExplosionSound;
    public AudioClip BranchSound;

    public Sprite village;
    public Sprite river;
    public Sprite darkForest;
    public Sprite darkForestReptilian;

    public Card mainCard;
    public Card oldMaxim;
    public Card meatPie;
    public Card baikalWater;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelMusic(BeginMusic));
        scripts.Add(new NovelSound(HorseSound));
        scripts.Add(new NovelAddCard(mainCard));
        scripts.Add(new NovelMind("��� ���� ����� ������� � ����� ������, ��������� ��������� ��� ���."));
        scripts.Add(new NovelSay("���������", "��, �����, ������� ��� ����� �� ��������������?"));
        scripts.Add(new NovelSay("�����", "���� ��� ���������, ������."));
        scripts.Add(new NovelSay("���������", "��� ��� �� ������, � ��� �� ������. ����� � ������� � ����������."));
        scripts.Add(new NovelSay("�����", "���������, ��� ���� ���������. � ��� ���� � ����� ������� �������?"));
        scripts.Add(new NovelSay("���������", "��� ������� ��� ������, ����� ���������."));
        scripts.Add(new NovelSay("�����", "� � ����� ������� ������ ���, �� ����� ����."));
        scripts.Add(new NovelSay("�����", "�������� �� ������� �� ����� ������ ��� � � �������������� ���������."));
        scripts.Add(new NovelSay("���������", "� ������, ��� ���� ����� �����."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("������ ��� ���������� � ������� �������."));
        scripts.Add(new NovelSay("�������", "�� ����� �������, ���� ������� �����."));
        scripts.Add(new NovelMind("������� �������� ���� ���� ��� �����������."));
        scripts.Add(new NovelMind("��������� ����� ���������� ����."));
        scripts.Add(new NovelSay("���������", "���� ���������. ������� � ����� ���� � ������. ���� �����..."));
        scripts.Add(new NovelSay("***", "�! ��������� ������� ��?"));
        scripts.Add(new NovelMind("���������� �������� �����."));
        scripts.Add(new NovelMind("��� ���� ������� �������."));
        scripts.Add(new NovelSay("���������", "���������� ������."));
        scripts.Add(new NovelSay("������� �������", "��, ������, ������� ���, ������� ��� ������. ����� ������ � ������� �������, �������� ����."));
        scripts.Add(new NovelSay("���������", "������ ������. ������ ���������� � �������."));
        scripts.Add(new NovelSay("�������", "�� ����� ��. � ����� ����, �� �������� ���."));
        scripts.Add(new NovelSay("���������", "�����. ��������."));
        scripts.Add(new NovelSound(null));
        scripts.Add(new NovelMind("������� ������������, ��������� ������ ���� ����� � ������."));
        scripts.Add(new NovelMind("���� �������� � ������� � ������ ����� ���� �������."));
        scripts.Add(new NovelSay("������� �������", "��-��. ������, �� ��� ���� ���������."));
        scripts.Add(new NovelSay("���������", "�� ���, ����������� ��� �� ���."));
        scripts.Add(new NovelSay("������� �������", "�� ��� � ������. ����� ����, �����."));
        scripts.Add(new NovelSay("������� �������", "��� ���� ����� ������. �� ��� ������ ���� �� ����� �������� ���� � ���� � ������ � ����� �� ����, � ��� ����."));
        scripts.Add(new NovelSay("���������", "����� � ��� ������."));
        scripts.Add(new NovelAddCard(meatPie));
        scripts.Add(new NovelAddCard(baikalWater));
        scripts.Add(new NovelSay("������� �������", "�����, � �� ���� ����� �� ���� ��� ���� �����, �� ������ ����������. � � ���� �� ���� ������ ������."));
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelMind("��������� ����� � �������� � ������� ��� ����� � ������."));
        scripts.Add(new NovelMind("�� ������ ����� � ������� ���������� ����� ���. ��������� ������� � ���� �������."));
        scripts.Add(new NovelSay("���������", "�� ���, ���� ������ �������?"));
        scripts.Add(new NovelSay("��� ������", "�. ���?"));
        scripts.Add(new NovelMind("��� ����� ���������, ���������� �������� � ����������� � �� ��� ���� ������� ������."));
        scripts.Add(new NovelSay("��� ������", "���, ��������� ��? ����������. ������ ������ ������ � �� ���� � ������� �� ���������� ��� ��� ��� ���� ������."));
        scripts.Add(new NovelSay("���������", "������� ��������, �� ������� ��������, ������� ������� ��������."));
        scripts.Add(new NovelMind("��������� �������� �������� � ���������."));
        scripts.Add(new NovelSay("��� ������", "� �� �� ������� �������."));
        scripts.Add(new NovelMusic(null));
        scripts.Add(new NovelSound(ExplosionSound));
        scripts.Add(new NovelMind("������ ��������� ����� ��������� ��� � ���� ��������� � �������� ������ �����."));
        scripts.Add(new NovelSay("��� ������", "��. ��� ��� ����?"));
        scripts.Add(new NovelSay("���������", "����� ���-�� �� �������. ����� ���������. �������, ��� �� �� � ��� � �����."));
        scripts.Add(new NovelSay("��� ������", "� ��� � �����."));
        scripts.Add(new NovelAddCard(oldMaxim));
        scripts.Add(new NovelSay("���������", "�� ������. ������ �� ����."));
        scripts.Add(new NovelBackground(darkForest));
        scripts.Add(new NovelMusic(LizardMusic));
        scripts.Add(new NovelMind("��������� � ����� �������� ������ ��������� � ����� ������ ��������� ���."));
        scripts.Add(new NovelMind("�������� ��� ���� ������ ��������� � ������ ���� ������."));
        scripts.Add(new NovelMind("��� ����������, ��� ���� ������� ����� ������ ������."));
        scripts.Add(new NovelBackground(darkForestReptilian));
        scripts.Add(new NovelMind("� ��� ��� ������� ��. ������."));
        scripts.Add(new NovelMind("�������������� ���������� �������� ���-�� ���������� ����� �� ����� ��������� ��������."));
        scripts.Add(new NovelMind("��������� ��������� �������� ���� ����� � ������ ������ ���."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���������� � �������."));
        scripts.Add(new NovelSay("��� ������", "*�������* ������� �� ����� ��� ����� �� ������. ����� ��� �������������."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���� ��������, ����� ��� ��� �� ��������."));
        scripts.Add(new NovelSound(BranchSound));
        scripts.Add(new NovelMind("� ��� ������������ �������� ����� ��� ������ ���� �������."));
        scripts.Add(new NovelMind("����� ����� ������������."));
        scripts.Add(new NovelMind("������� ���� � ������������� �������� �������� � ������� �����."));
        scripts.Add(new NovelSay("���������", "������� �������."));
        scripts.Add(new NovelStartScene("FirstBattle", "�������� ������", SceneType.battle));

        PlayScript();
    }
}
