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
        scripts.Add(new NovelMind("Под стук колес повозки и копыт лошади, Пиздослав проснулся ото сна."));
        scripts.Add(new NovelSay("Пиздослав", "Эй, кучер, сколько еще ехать до Древнеславянки?"));
        scripts.Add(new NovelSay("Кучер", "Вона уже виднеется, хлопец."));
        scripts.Add(new NovelSay("Пиздослав", "Вот тут ты ошибся, я ужо не хлопец. Служу в дружине у Дрочеслава."));
        scripts.Add(new NovelSay("Кучер", "Дружинник, это дело праведное. А что тебе в нашей деревне надобно?"));
        scripts.Add(new NovelSay("Пиздослав", "Дык деревня моя родная, родню навестить."));
        scripts.Add(new NovelSay("Кучер", "Я в вашей деревне только год, не помню тебя."));
        scripts.Add(new NovelSay("Кучер", "Наверное ты служить то уехал раньше чем я в Древнеславянке поселился."));
        scripts.Add(new NovelSay("Пиздослав", "И правда, три года назад уехал."));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMind("Телега уже подъезжала к окраине деревни."));
        scripts.Add(new NovelSay("Конемир", "Ну будем знакомы, меня Конемир звать."));
        scripts.Add(new NovelMind("Конемир протянул свою руку для рукопожатия."));
        scripts.Add(new NovelMind("Пиздослав пожал протянутую руку."));
        scripts.Add(new NovelSay("Пиздослав", "Меня Пиздослав. Назвали в честь отца и матери. Отца звали..."));
        scripts.Add(new NovelSay("***", "О! Пиздослав неужели ты?"));
        scripts.Add(new NovelMind("Послышался знакомый голос."));
        scripts.Add(new NovelMind("Это была бабушка Авдотья."));
        scripts.Add(new NovelSay("Пиздослав", "Здравствуй бабуль."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Ох, родной, сколько лет, сколько зим прошло. Давай слезай с повозки быстрее, голодный поди."));
        scripts.Add(new NovelSay("Пиздослав", "Сейчас бабуль. Только расплачусь с Кучером."));
        scripts.Add(new NovelSay("Конемир", "Да брось ты. Я помог тебе, ты поможешь мне."));
        scripts.Add(new NovelSay("Пиздослав", "Добро. Увидимся."));
        scripts.Add(new NovelSound(null));
        scripts.Add(new NovelMind("Повозка остановилась, Пиздослав забрал свой мешок с вещами."));
        scripts.Add(new NovelMind("Внук спрыгнул с повозки и крепко обнял свою бабушку."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Ой-ой. Потише, ты так меня раздавишь."));
        scripts.Add(new NovelSay("Пиздослав", "Ну что, рассказывай как вы тут."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Да как и всегда. Живем тихо, мирно."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Вот деду несла пироги. Он как всегда ушел на речку рыбачить рано с утра и ничего с собой не взял, а уже обед."));
        scripts.Add(new NovelSay("Пиздослав", "Давай я ему отнесу."));
        scripts.Add(new NovelAddCard(meatPie));
        scripts.Add(new NovelAddCard(baikalWater));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Давай, а то пока дойду до него уже ужин будет, ты быстро доберешься. И я пока на тебя пироги испеку."));
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelMind("Пиздослав зашел в знакомый с детства лес рядом с речкой."));
        scripts.Add(new NovelMind("На берегу сидел с удочкой коренастый седой дед. Пиздослав подошел к деду поближе."));
        scripts.Add(new NovelSay("Пиздослав", "Ну что, всех окуней выловил?"));
        scripts.Add(new NovelSay("Дед Максим", "А. Кто?"));
        scripts.Add(new NovelMind("Дед начал озираться, встретился взглядом с Пиздославом и на его лице засияла улыбка."));
        scripts.Add(new NovelSay("Дед Максим", "Ооо, Пиздослав ты? Здравствуй. Сейчас удочки сверну и по пути в деревню ты расскажешь как эти три года провел."));
        scripts.Add(new NovelSay("Пиздослав", "Конечно расскажу, но сначала отобедай, бабушка пирожки передала."));
        scripts.Add(new NovelMind("Пиздослав протянул корзинку с пирожками."));
        scripts.Add(new NovelSay("Дед Максим", "А мы их пополам поделим."));
        scripts.Add(new NovelMusic(null));
        scripts.Add(new NovelSound(ExplosionSound));
        scripts.Add(new NovelMind("Только Пиздослав хотел возразить как в небе вспыхнуло и раздался гулкий взрыв."));
        scripts.Add(new NovelSay("Дед Максим", "Ох. Что это было?"));
        scripts.Add(new NovelSay("Пиздослав", "Упало где-то на востоке. Нужно проверить. Надеюсь, это не то о чем я думаю."));
        scripts.Add(new NovelSay("Дед Максим", "Я иду с тобой."));
        scripts.Add(new NovelAddCard(oldMaxim));
        scripts.Add(new NovelSay("Пиздослав", "Ну хорошо. Только не шуми."));
        scripts.Add(new NovelBackground(darkForest));
        scripts.Add(new NovelMusic(LizardMusic));
        scripts.Add(new NovelMind("Пиздослав с дедом Максимом начали подходить к месту откуда доносился шум."));
        scripts.Add(new NovelMind("Казалось что небо вокруг почернело и воздух стал вязким."));
        scripts.Add(new NovelMind("Что Пиздославу, что деду Максиму стало трудно дышать."));
        scripts.Add(new NovelBackground(darkForestReptilian));
        scripts.Add(new NovelMind("И тут они увидели их. Ящеров."));
        scripts.Add(new NovelMind("Отвратительные чешуйчатые создания что-то копошились рядом со своим воздушным кораблем."));
        scripts.Add(new NovelMind("Пиздослав аккуратно поставил свой мешок и достал оттуда меч."));
        scripts.Add(new NovelSay("Пиздослав", "*Шепотом* Нужно рассказать в деревне."));
        scripts.Add(new NovelSay("Дед Максим", "*Шепотом* Никогда не думал что увижу их вживую. Какие они омерзительные."));
        scripts.Add(new NovelSay("Пиздослав", "*Шепотом* Давай тихо отходить, чтобы они нас не заметили."));
        scripts.Add(new NovelSound(BranchSound));
        scripts.Add(new NovelMind("И тут предательски треснула ветка под ногами деда Максима."));
        scripts.Add(new NovelMind("Ящеры вдруг остановились."));
        scripts.Add(new NovelMind("Десятки глаз с вертикальными зрачками смотрели в сторону русов."));
        scripts.Add(new NovelSay("Пиздослав", "Придётся драться."));
        scripts.Add(new NovelStartScene("FirstBattle", "Крущение ящеров", SceneType.battle));

        PlayScript();
    }
}
