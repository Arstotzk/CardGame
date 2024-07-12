using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildhoodDream : NovelManager
{
    public Card cardChoose1_1;
    public Card cardChoose1_2;
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelMind("TODO ��� ��� �������"));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelMind("TODO ����� �����"));
        scripts.Add(new NovelStartScene("SecondVillageBattle", "��������� ������ ����� ������ �� �������", SceneType.battle));
        PlayScript();
    }
}
