using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    Transform stat;
    public static List <Text> statDisplay = new List<Text>();

	// Use this for initialization
	void Start ()
    {
        stat = GameObject.Find("Canvas/ItemStats").GetComponent<Transform>();
        foreach (Transform child in stat)
        {
            ///child.GetComponent<Text>();
            statDisplay.Add(child.GetComponent<Text>());
        }
    }
	

}
