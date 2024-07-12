using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadToVillage : NovelManager
{
    public Card cardChoose1_1;
    public Card cardChoose1_2;
    public Card cardChoose2_1;
    public Card cardChoose2_2;
    void Start()
    {
        Debug.Log("NewGameStart: " + scriptNumber);
        scripts.Add(new NovelMind("TODO ������ � �������"));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelMind("TODO ����� ��� �����"));
        scripts.Add(new NovelChooseCard(cardChoose2_1, cardChoose2_2));
        scripts.Add(new NovelMind("TODO ����� �����"));
        scripts.Add(new NovelStartScene("FirstVillageBattle", "������ ����� ������ �� �������", SceneType.battle));
        PlayScript();
    }
}
