using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Text _desc;
    public static Text _name;
    public static Image _image;
    public static Image dmgBar;
    public static Image frBar;
    public static Image rlBar;
    public static Image capBar;
    public static Image accBar;
    public static Image ccBar;
    public static Image cdBar;
    public static GameObject inventory;
    public static CanvasGroup fade;
    public static GameObject inventoryContent;
    public static Text healthText;
    public static Text weightText;

    public static AudioSource _select;
    public static AudioSource _drop;


    void Awake()
    {
        inventory = gameObject;
        inventoryContent = transform.Find("ScrollRect/Content").gameObject;
        fade = gameObject.GetComponent<CanvasGroup>();
        _desc = GameObject.Find("Canvas/Inventory/Desc/ItemDesc").GetComponent<Text>();
        _name = GameObject.Find("Canvas/Inventory/Desc/ItemName").GetComponent<Text>();
        _image = GameObject.Find("Canvas/Inventory/Desc/ItemImage").GetComponent<Image>();
        dmgBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/Damage/Image/Image").GetComponent<Image>();
        frBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/FireRate/Image/Image").GetComponent<Image>();
        rlBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/Reload/Image/Image").GetComponent<Image>();
        capBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/Capacity/Image/Image").GetComponent<Image>();
        accBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/Accuracy/Image/Image").GetComponent<Image>();
        ccBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/CriticalChance/Image/Image").GetComponent<Image>();
        cdBar = GameObject.Find("Canvas/Inventory/WeaponStats/Panels/CriticalDamage/Image/Image").GetComponent<Image>();
        _select = GameObject.Find("Canvas/Inventory/InventorySounds/Select").GetComponent<AudioSource>();
        _drop = GameObject.Find("Canvas/Inventory/InventorySounds/Drop").GetComponent<AudioSource>();

        weightText = GameObject.Find("Canvas/Inventory/Health").GetComponent<Text>();
        healthText = GameObject.Find("Canvas/Inventory/CurrentWeight").GetComponent<Text>();
    }

}
