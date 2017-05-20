﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    public GameObject inventoryWeaponPrefab;
    BaseWeapon dropWeapon = new BaseWeapon();
    void Start()
    {
        if (gameObject.GetComponent<CreateNewWeapon>())
        {
            CreateNewWeapon w = gameObject.GetComponent<CreateNewWeapon>();
            dropWeapon = w.NewWeapon;
            Destroy(w);
        }
    }
    public void DropWeapon(BaseWeapon myWeapon)
    {
        dropWeapon = myWeapon;
        gameObject.GetComponent<WeaponDisplay>().myText.text = dropWeapon.WeaponTypes.ToString();
    }
    public BaseWeapon WeaponStats
    {
        get { return dropWeapon; }
    }

    public void PickedUp()
    {
        if ((PlayerStats.curWeight + dropWeapon.Weight) <= PlayerStats.maxWeight)
        {
            GameObject clone;
            clone = Instantiate(inventoryWeaponPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.inventoryContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.GetComponent<InventoryWeapon>().pickedUpWeapon(dropWeapon);
            clone.SetActive(true);
            InventoryList.itemList.Add(clone);
            InventoryList.weaponList.Add(clone);
            PlayerStats.curWeight += dropWeapon.Weight;
            StartCoroutine(ItemObtained());
        }
        else
            StartCoroutine(NoStrength());
    }

    IEnumerator ItemObtained()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropWeapon.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You've obtained the " + "\"" + dropWeapon.ItemName + "\"" + " " + dropWeapon.WeaponTypes +".";
        GameManagerScript.itemInfoText.text = GameManagerScript.itemInfoText.text.Replace(dropWeapon.WeaponTypes.ToString(), "<color=#FFFFFFFF>" + dropWeapon.WeaponTypes.ToString() + "</color>");
        GameManagerScript.stat.gameObject.SetActive(false);
        PlayerStats.curWeight += dropWeapon.Weight;
        Time.timeScale = 0;
        AmmoDisplay.isActive = false;
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropWeapon.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        AmmoDisplay.isActive = false;
        //GameManagerScript.stat.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
