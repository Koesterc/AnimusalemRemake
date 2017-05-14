﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArmor : MonoBehaviour
{
    public GameObject inventoryArmorPrefab;
    BaseArmor dropArmor = new BaseArmor();

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
        gameObject.GetComponent<ItemDisplay>().myText.text = dropArmor.ArmorTypes.ToString()+" Armor";
        //subtract player's weight
    }

    public void PickedUp()
    {
        GameObject clone;
        clone = Instantiate(inventoryArmorPrefab, Inventory.inventoryContent.transform.position, transform.rotation) as GameObject;
        clone.transform.SetParent(Inventory.inventoryContent.transform, true);
        clone.transform.localScale = new Vector3 (1,1,1);
        clone.GetComponent<InventoryArmor>().pickedUpArmor(dropArmor);
        InventoryList.itemList.Add(clone.gameObject);
        Destroy(gameObject);
    }

    public BaseArmor ArmorStats
    {
        get { return dropArmor; }
    }

}
