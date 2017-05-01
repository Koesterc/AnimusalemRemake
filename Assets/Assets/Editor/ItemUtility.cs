using UnityEngine;
using System.Collections;
using UnityEditor;

public class ItemUtility
{

    [MenuItem("Assets/Create/RPG/Item")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<Item>();
    }
}
