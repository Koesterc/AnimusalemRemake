using UnityEngine;
using System.Collections;
using UnityEditor;

public class ItemUtility
{

    [MenuItem("Assets/Create/RPG/BaseItem")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<BaseItem>();
    }
}
