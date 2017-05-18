using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    [SerializeField]
    GameObject _inventory;
    [SerializeField]
    GameObject _inventoryContent;
    [SerializeField]
    GameObject _UIevent;
    [SerializeField]
    GameObject _playerStats;
    public static GameObject inventory;
    public static GameObject inventoryContent;
    public static UnityEngine.EventSystems.EventSystem UIevent;
    public static GameObject playerStats;


    // Update is called once per frame
    void Awake ()
    {
        UIevent = _UIevent.GetComponent<UnityEngine.EventSystems.EventSystem>();
        inventory = _inventory;
        inventoryContent = _inventoryContent;
        Inventory.fade = inventory.GetComponent<CanvasGroup>();
        playerStats = _playerStats;
    }
}
