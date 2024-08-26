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
        scripts.Add(new NovelMind("Русы перебили всех ящеров до единого."));
        scripts.Add(new NovelSay("Пиздослав", "Братцы, это точно ваша первая битва? Как мы ловко их. Я даже сначала не понял, молодцы."));
        scripts.Add(new NovelSay("Пиздослав", "Нужно быстрее вернутся в деревню, ящеры могли идти с двух сторон."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("Отряд Пиздослава вернулся в деревню."));
        scripts.Add(new NovelMind("Судя по всему на нее никто не напал."));
        scripts.Add(new NovelMind("Пиздаслав направился к старосте деревни."));
        scripts.Add(new NovelSay("Пиздослав", "Тех ящеров мы перебили. Не было видно других на горизонте?"));
        scripts.Add(new NovelSay("Староста", "Это хорошо. Как ты и говорил, мы расставили часовых, но кроме первых ящеров никого не заметили."));
        scripts.Add(new NovelSay("Пиздослав", "Не к добру это. Не в их духе."));
        scripts.Add(new NovelSay("Староста", "Но пока у нас все нормально. Мужики возводят частокол. Ты лучше пойди и отдохни, вечереет уже. Ты самый опытный боец среди нас, и должен быть в добром духе."));
        scripts.Add(new NovelSay("Пиздослав", "Да, пожалуй ты прав. Намахался я за сегодня мечем."));
        scripts.Add(new NovelMind("Пиздаслав вместе с дедом Максимом пошли в их дом."));
        scripts.Add(new NovelSay("Дед Максим", "Ладно, ты давай иди в баньку и отдохни. А с бабкой я сам поговорю. Сам знаешь ей во всех подробностях все знать надо. Замучает тебя так на несколько часов болтовни."));
        scripts.Add(new NovelBackground(villagePlace));
        scripts.Add(new NovelMind("Пиздаслав кивнул деду и ушел смывать кровь ящеров со своего тела."));
        scripts.Add(new NovelMind("После бани он лег на уже приготовленную перину. Мышцы его гудели и от усталости он быстро заснул."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("Утро. С первыми лучами солнца Пиздослав проснулся и собрался к Старосте."));
        scripts.Add(new NovelSay("Староста", "Доброе утро. Ты как раз вовремя, тут новый доброволец в твой отряд нашелся."));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelSay("Пиздослав", "Побольше бы таких в мой отряд. Но имеем что имеем."));
        scripts.Add(new NovelSay("Староста", "Я послал гонцов в ближайшие деревни, может еще подойдут добротные войны, или хотя бы снаряжение."));
        scripts.Add(new NovelSay("Часовой", "Староста, увидели очередных ящеров. Теперь идут уже с востока."));
        scripts.Add(new NovelSay("Пиздослав", "Запоздало они, но это нам на руку. Действуем по старой схеме, я со своим отрядом на перехват. Остальные, не опытные бойцы на защиту деревни."));
        scripts.Add(new NovelStartScene("SecondVillageBattle", "Очередная подлая атака ящеров на деревню", SceneType.battle));
        PlayScript();
    }
}
