using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    //Inventory
    [Header("These gameobjects are chilren to the inventory")]
    [SerializeField]
    GameObject _inventory;
    [SerializeField]
    GameObject _inventoryContent;
    public static GameObject inventory;
    public static GameObject inventoryContent;
    //UI event
    [Header("UI event system gameobject")]
    [SerializeField]
    GameObject _UIevent;
    public static UnityEngine.EventSystems.EventSystem UIevent;
    //Player stats
    [Header("Player stats")]
    [SerializeField]
    GameObject _playerStats;
    public static GameObject playerStats;

    //dialogue manager
    [Header("Dialogue Box")]
    [SerializeField]
    GameObject _dialogueBox;
    public static GameObject dialogueBox;
    [SerializeField]
    Text _textField;
    public static Text textField;
    [SerializeField]
    Text _optionOne;
    public static Text optionOne;
    [SerializeField]
    Text _optionTwo;
    public static Text optionTwo;
    [SerializeField]
    Text _optionThree;
    public static Text optionThree;

    //dybbuk shop
    [Header("These gameobjects are chilren to the dybbuk shop")]
    [SerializeField]
    GameObject _dibbukShop;
    [SerializeField]
    GameObject _sellContent;
    [SerializeField]
    GameObject _buyContent;
    [SerializeField]
    GameObject _upgradeContent;
    public static GameObject dibbukShop;
    public static GameObject sellContent;
    public static GameObject buyContent;
    public static GameObject upgradeContent;
    //UI screen effect effect
    [Header("The child of screen effect (Canvas > ScreenEffect > Image)")]
    [SerializeField]
    Animator _screenEffect;
    public static Animator screenEffect;

    // Update is called once per frame
    void Awake ()
    {
        UIevent = _UIevent.GetComponent<UnityEngine.EventSystems.EventSystem>();
        inventory = _inventory;
        inventoryContent = _inventoryContent;
        Inventory.fade = inventory.GetComponent<CanvasGroup>();
        playerStats = _playerStats;
        buyContent = _buyContent;
        sellContent = _sellContent;
        upgradeContent = _upgradeContent;
        dibbukShop = _dibbukShop;
        screenEffect = _screenEffect;
        dialogueBox = _dialogueBox;
        textField = _textField;
        optionOne = _optionOne;
        optionTwo = _optionTwo;
        optionThree= _optionThree;
    }
}
