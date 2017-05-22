using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DybbukShop : MonoBehaviour {
    public static GameObject sellContent;
    public static GameObject buyContent;
    public static GameObject upgradeContent;
    [SerializeField]
    public GameObject _sellContent;
    [SerializeField]
    GameObject _buyContent;
    [SerializeField]
    GameObject _upgradeContent;


    // Use this for initialization
    void Awake()
    {
        sellContent = _sellContent;
        buyContent = _buyContent;
        upgradeContent = _upgradeContent;
    }

}
