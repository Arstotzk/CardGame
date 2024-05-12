using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SceneStore : MonoBehaviour
{
    public List<SceneData> sceneDatas;

    public SceneData GetScene(string name)
    {
        return sceneDatas.Where(sd => sd.Name.Equals(name)).FirstOrDefault();
    }
}
