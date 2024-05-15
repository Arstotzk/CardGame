using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public string Name;
    public string NameRu;
    public List<Card> cards;
    public List<SceneCard> cardsOnBattle;
    public string nextSceneName;
    public string nextSceneNameRu;
}

[System.Serializable]
public class SceneCard
{
    public Card card;
    public int row;
    public int column;
}
