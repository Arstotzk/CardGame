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
        scripts.Add(new NovelMind("После жаркой битвы с ящерами у Пиздослава и деда Максима пот катился ручьем."));
        scripts.Add(new NovelSay("Дед Максим", "Ох и тяжко с ними драться. Юркие заразы. Только прицелишься, а он в другое место перебежит."));
        scripts.Add(new NovelSay("Пиздослав", "Это мы еще на слабых нарвались. От них мы отбились, но на шум скоро еще подойдут, нужно уходить и быстро."));
        scripts.Add(new NovelSound(null));
        scripts.Add(new NovelBackground(village));
        scripts.Add(new NovelMusic(BeginMusic));
        scripts.Add(new NovelMind("Русы мигом добежали до деревни."));
        scripts.Add(new NovelMind("На входе в деревню им встретилась бабушка Авдотья."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "Ох родные, долго вы там. Видели сверкнуло в небе как гром? А на небе не тучки."));
        scripts.Add(new NovelSay("Пиздослав", "И плохо что сверкнуло. Всех собирай у старосты, мы сейчас к нему идем."));
        scripts.Add(new NovelSay("Бабушка Авдотья", "А что случилось то?"));
        scripts.Add(new NovelSay("Дед Максим", "Худо. У старосты все расскажем."));
        scripts.Add(new NovelMind("Без лишнего промедления они дошли до старосты деревни."));
        scripts.Add(new NovelSay("Староста", "Здаров Максим. А ты? Неужели Пиздослав, вернулся наконец."));
        scripts.Add(new NovelSay("Пиздослав", "Да, вернулся, но с плохими вестями."));
        scripts.Add(new NovelSay("Староста", "А что же могло случится в нашей тихой деревне?"));
        scripts.Add(new NovelSay("Пиздослав", "Недалеко за речкой упал ящерский воздушный корабль. Судя по вооружению это только разведчики. Пока что."));
        scripts.Add(new NovelSay("Староста", "Их же отродясь тут не водилось. Что же они тут забыли?"));
        scripts.Add(new NovelSay("Пиздослав", "Я пока не понимаю, но они явно задумали что-то подлое."));
        scripts.Add(new NovelSay("Пиздослав", "Нужно собрать всех деревенских и рассказать им."));
        scripts.Add(new NovelSay("Староста", "Полностью согласен, сейчас все сделаем."));
        scripts.Add(new NovelBackground(villagePlace));
        scripts.Add(new NovelMind("Спустя некоторое время все жители деревни собрались на главной площади."));
        scripts.Add(new NovelSay("Деревенские", "А что нас тут всех собрали?"));
        scripts.Add(new NovelSay("Деревенские", "Наверное что-то серьёзное."));
        scripts.Add(new NovelSay("Деревенские", "У меня дел не в проворот, а тут собраниями дурацкими отвлекают."));
        scripts.Add(new NovelMind("На импровизированную трибуну зашли Староста и Пиздослав."));
        scripts.Add(new NovelSay("Староста", "Прошу всех тишины."));
        scripts.Add(new NovelMind("Галдеж начал стихать."));
        scripts.Add(new NovelSay("Староста", "Беда надвигается на нашу деревню. Пиздослав с Максимом наткнулись неподалеку на ящеров."));
        scripts.Add(new NovelSay("Деревенские", "Ящеры у нас?"));
        scripts.Add(new NovelSay("Деревенские", "Этого не может быть."));
        scripts.Add(new NovelSay("Деревенские", "Кто нас защитит?"));
        scripts.Add(new NovelSay("Староста", "Так как я в ящерах не разбираюсь, то передам слово Пиздославу, он расскажет план наших действий."));
        scripts.Add(new NovelSay("Пиздослав", "Да, действительно беда случилась, но это не повод сложить руки."));
        scripts.Add(new NovelSay("Пиздослав", "Вместе мы дадим отпор ящерской погани."));
        scripts.Add(new NovelSay("Пиздослав", "Перво наперво необходимо послать гонца к моему воеводе, Дрочеславу. Кто желает?"));
        scripts.Add(new NovelSay("Конемир", "Я могу дать своего лучшего коня!"));
        scripts.Add(new NovelSay("Деревенский юноша", "Я желаю, в деревне нет наездника лучше меня."));
        scripts.Add(new NovelSay("Конемир", "Да, я подтверждаю и остальные думаю тоже."));
        scripts.Add(new NovelMind("Пиздослав позвал юношу к трибуне и передал ему письмо."));
        scripts.Add(new NovelSay("Пиздослав", "Береги как зеницу ока. Езжай по северной дороге до Новгорода, там лагерь Дрочеслава."));
        scripts.Add(new NovelSay("Деревенский юноша", "Домчусь быстрее ветра!"));
        scripts.Add(new NovelMind("Конемир с юношей быстро ушли в строну конюшни."));
        scripts.Add(new NovelSay("Пиздослав", "Зная ящерскую тактику, я предполагаю что они решат напасть на нашу деревню."));
        scripts.Add(new NovelSay("Пиздослав", "Поэтому нам необходимо подготовится к обороне как можно лучше."));
        scripts.Add(new NovelSay("Пиздослав", "Я понимаю что мало кто из вас дрался с ящерами, но я постараюсь как можно лучше вас обучить."));
        scripts.Add(new NovelSay("Пиздослав", "Так же мне необходимы лучшие из вас, для формирования собственного отряда."));
        scripts.Add(new NovelSay("Староста", "К сожалению у нас деревня не богатая и тебе нужно выбрать какие именно будут новобранцы."));
        scripts.Add(new NovelChooseCard(cardChoose1_1, cardChoose1_2));
        scripts.Add(new NovelMind("Есть еще добровольцы, Пиздослав решает их обучить по другому."));
        scripts.Add(new NovelChooseCard(cardChoose2_1, cardChoose2_2));
        scripts.Add(new NovelSay("Пиздослав", "Остальные, кто может драться, вооружайтесь вилами и топорами."));
        scripts.Add(new NovelSay("Пиздослав", "По периметру деревни должны стоять часовые."));
        scripts.Add(new NovelSay("Пиздослав", "Еще нам необходимы укрепления."));
        scripts.Add(new NovelSay("Конемир", "Идут, они идут!"));
        scripts.Add(new NovelMind("Вбежав на площадь, прокричал запыхавшийся Конемир."));
        scripts.Add(new NovelMind("Среди деревенских началась паника."));
        scripts.Add(new NovelSay("Пиздослав", "Всем тихо, не паниковать. Где ты их видел?"));
        scripts.Add(new NovelSay("Конемир", "Только снарядил юношу провизией и увидел как они идут с запада, по дороге. В часе ходьбы будут здесь."));
        scripts.Add(new NovelSay("Пиздослав", "Все кто не может драться, прячьтесь в домах, но будьте готовы бросить все и бежать в сторону Новгорода."));
        scripts.Add(new NovelSay("Пиздослав", "Остальные охраняйте деревню, они могут напасть еще с другой стороны."));
        scripts.Add(new NovelSay("Пиздослав", "Я со своим отрядом перехвачу их и заставлю драться на своих условиях."));
        scripts.Add(new NovelSay("Пиздослав", "Деревня обязательно выживет!"));
        scripts.Add(new NovelSay("Деревенские", "Ура! Гойда!"));
        scripts.Add(new NovelBackground(river));
        scripts.Add(new NovelMind("Отряд Пиздослава вышел из деревни так, чтобы их не было видно с западной дороги."));
        scripts.Add(new NovelMind("Русы спрятались за деревьями рядом с дорогой в ожидании боя."));
        scripts.Add(new NovelMind("Мимо них начали проходить ничего не подозревающие ящерские войны. Идеальный момент для нападения."));
        scripts.Add(new NovelStartScene("FirstVillageBattle", "Подлая атака ящеров на деревню", SceneType.battle));
        PlayScript();
    }
}
