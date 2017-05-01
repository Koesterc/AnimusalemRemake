using UnityEngine;
using System.Collections;
using UnityEditor;

public class GameUtility
{

    [MenuItem("Assets/Create/RPG/GameInfo")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<GameInfo>();
    }
}
