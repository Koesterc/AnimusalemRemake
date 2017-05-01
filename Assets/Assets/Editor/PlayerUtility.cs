using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerUtility
{

    [MenuItem("Assets/Create/RPG/Player")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<PlayerStats>();
    }
}
