﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedArmor : MonoBehaviour
{
    public GameObject inventoryArmorPrefab;
    BaseArmor dropArmor = new BaseArmor();
    [SerializeField]
    GameObject shopArmorPrefab;

    void Start()
    {
        if (gameObject.GetComponent<CreateNewArmor>())
        {
            CreateNewArmor a = gameObject.GetComponent<CreateNewArmor>();
            dropArmor = a.NewArmor;
            Destroy(a);
        }
    }
    public void DropArmor(BaseArmor myArmor)
    {
        dropArmor = myArmor;
        gameObject.GetComponent<ArmorDisplay>().myText.text = dropArmor.ArmorTypes.ToString()+" Armor";
    }

    public void PickedUp()
    {
        if ((PlayerStats.curWeight + dropArmor.Weight) <= PlayerStats.maxWeight)
        {
            GameObject clone;
            clone = Instantiate(inventoryArmorPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.inventoryContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.SetActive(true);
            clone.GetComponent<InventoryArmor>().pickedUpArmor(dropArmor);
            InventoryList.itemList.Add(clone);
            PlayerStats.curWeight += dropArmor.Weight;
            StartCoroutine(ItemObtained());

            ////adding the gameobject to the sell list
            clone = Instantiate(shopArmorPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.sellContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            //transfering the data
            clone.gameObject.GetComponent<DybbukArmor>().TransferData(dropArmor);
            clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.SellValue.ToString("n0");
            clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.ItemName.ToString();
            clone.transform.FindChild("Level").GetComponent<Text>().text = "Level: " + clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.LevelRestriction.ToString();
            clone.SetActive(true);
            InventoryList.sellList.Add(clone);
        }
        else
           StartCoroutine (NoStrength());
    }

    public BaseArmor ArmorStats
    {
        get { return dropArmor; }
    }

    IEnumerator ItemObtained()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropArmor.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You've obtained the " + "\"" + dropArmor.ItemName + "\"" + " " + dropArmor.ArmorTypes + ".";
        GameManagerScript.itemInfoText.text = GameManagerScript.itemInfoText.text.Replace(dropArmor.ArmorTypes.ToString(), "<color=#FFFFFFFF>" + dropArmor.ArmorTypes.ToString() + "</color>");
        Time.timeScale = 0;
        AmmoDisplay.isActive = false;
        GameManagerScript.stat.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropArmor.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        Time.timeScale = 0;
        gameObject.GetComponent<ArmorDisplay>().pickUp = true;
    }

}
