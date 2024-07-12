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
        scripts.Add(new NovelMind("TODO сон про детство"));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelMind("TODO Новая битва"));
        scripts.Add(new NovelStartScene("SecondVillageBattle", "Очередная подлая атака ящеров на деревню", SceneType.battle));
        PlayScript();
    }
}
