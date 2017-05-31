using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //stats
    public static Transform stat;
    //stats
    [SerializeField]
    Transform _itemStats;
    //inventory
    public static List <Text> statDisplay = new List<Text>();
    //item pickup information
    public static GameObject itemInfo;
    public static Text itemInfoText;
    public static Image itemInfoImage;
    [SerializeField]
    GameObject _itemInfo;
    [SerializeField]
    Text _itemInfoText;
    [SerializeField]
    Image _itemInfoImage;
    //gamespeed
    public static float gameSpeed = 1f;
    public static bool isActive;
    [SerializeField]
    GameObject _player;
    public static GameObject player;

    // Use this for initialization
    void Start ()
    {
        stat = _itemStats;
        itemInfo = _itemInfo;
        itemInfoText = _itemInfoText;
        itemInfoImage = _itemInfoImage;
        itemInfo.SetActive(false);
        player = _player;

        foreach (Transform child in stat)
        {
            ///child.GetComponent<Text>();
            statDisplay.Add(child.GetComponent<Text>());
        }
        stat.gameObject.SetActive(false);
    }
	

}
