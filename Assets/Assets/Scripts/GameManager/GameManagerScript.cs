using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //stats
    public static Transform stat;
    //inventory
    public static List <Text> statDisplay = new List<Text>();
    //item pickup information
    public static GameObject itemInfo;
    public static Text itemInfoText;
    public static Image itemInfoImage;
    //gamespeed
    public static float gameSpeed = 1f;

    // Use this for initialization
    void Start ()
    {
        stat = GameObject.Find("Canvas/ItemStats").GetComponent<Transform>();
        itemInfo= GameObject.Find("Canvas/ItemInformation");
        itemInfoText = GameObject.Find("Canvas/ItemInformation/TextFrame/Text").GetComponent<Text>();
        itemInfoImage = GameObject.Find("Canvas/ItemInformation/Image").GetComponent<Image>();
        itemInfo.SetActive(false);
        foreach (Transform child in stat)
        {
            ///child.GetComponent<Text>();
            statDisplay.Add(child.GetComponent<Text>());
        }
        stat.gameObject.SetActive(false);
    }
	

}
