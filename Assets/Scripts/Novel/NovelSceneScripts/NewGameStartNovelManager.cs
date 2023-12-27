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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        //����� ������
        scripts.Add(new NovelMusic(BeginMusic));
        //����� ����� �������
        scripts.Add(new NovelSound(HorseSound));
        scripts.Add(new NovelMind("��� ���� ����� ������� � ��� ������, ��������� ��������� ��� ���."));
        scripts.Add(new NovelSay("���������", "��, �����, ������� ��� ����� �� ��������������?"));
        scripts.Add(new NovelSay("�����", "���� ��� ���������, ������."));
        scripts.Add(new NovelSay("���������", "��� ��� �� ������, � ��� �� ������. ����� � ������� � ����������."));
        scripts.Add(new NovelSay("�����", "���������, ��� ���� ���������. � ��� ���� � ����� ������� �������?"));
        scripts.Add(new NovelSay("���������", "��� ������� ��� ������, ����� ���������."));
        scripts.Add(new NovelSay("�����", "� � ����� ������� ������ ���, �� ����� ����."));
        scripts.Add(new NovelSay("�����", "�������� �� ������� ����� ������ ��� � � �������������� ���������."));
        scripts.Add(new NovelSay("���������", "� ������, ��� ���� ����� �����."));
        //������ ��� �� �������
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
        //��������� ����� �������
        scripts.Add(new NovelSound(null));
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
        //���������� ������
        scripts.Add(new NovelMusic(null));
        //���� ������
        scripts.Add(new NovelSound(ExplosionSound));
        scripts.Add(new NovelMind("������ ��������� ����� ��������� ��� � ���� ��������� � �������� ������ �����."));
        scripts.Add(new NovelSay("��� ������", "��. ��� ��� ����?"));
        scripts.Add(new NovelSay("���������", "����� ���-�� �� �������. ����� ���������. ������� ��� �� �� � ��� � �����."));
        scripts.Add(new NovelSay("��� ������", "� ��� � �����."));
        scripts.Add(new NovelSay("���������", "�� ����, ������. ������ �� ����."));
        //����� ������ ������
        scripts.Add(new NovelMusic(LizardMusic));
        scripts.Add(new NovelMind("��������� � ����� �������� ������ ��������� � ����� ������ ��������� ���."));
        scripts.Add(new NovelMind("�������� ��� ���� ������ ��������� � ������ ���� ������."));
        scripts.Add(new NovelMind("��� ����������, ��� ���� ������� ����� ������ ������."));
        scripts.Add(new NovelMind("� ��� ��� ������� ��. ������."));
        scripts.Add(new NovelMind("�������������� ���������� �������� ���-�� ���������� ����� �� ����� ��������� ��������."));
        scripts.Add(new NovelMind("��������� ��������� �������� ���� ����� � ������ ������ ���."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���������� � �������."));
        scripts.Add(new NovelSay("��� ������", "*�������* ������� �� ����� ��� ����� �� ������. ����� ��� �������������."));
        scripts.Add(new NovelSay("���������", "*�������* ����� ���� ��������, ����� ��� ��� �� ��������."));
        //����� �����
        scripts.Add(new NovelSound(BranchSound));
        scripts.Add(new NovelMind("� ��� ������������ �������� ����� ��� ������ ���� �������."));
        scripts.Add(new NovelMind("����� ����� ������������."));
        scripts.Add(new NovelMind("������� ���� � ������������� ������� �������� � ������� �����."));
        scripts.Add(new NovelSay("���������", "��������� �������."));
        //������ ����� �����

        PlayScript();
    }
}
