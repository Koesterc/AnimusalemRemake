using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryArmor : MonoBehaviour
{
    private BaseArmor itemArmor;
    public GameObject droppedArmor;
    private void Start()
    {
        if (gameObject.GetComponent<CreateNewArmor>())
        {
            CreateNewArmor a = gameObject.GetComponent<CreateNewArmor>();
            itemArmor= a.NewArmor;
            Destroy(a);
        }
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemArmor.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemArmor.ItemName;
    }
    public void DroppedArmor()
    {
        if (Input.GetKeyDown("return"))
        {
            InventorySounds.drop.Play();
            GameObject clone;
            Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
            clone = Instantiate(droppedArmor, pos, transform.rotation) as GameObject;
            clone.GetComponent<DroppedArmor>().DropArmor(itemArmor);
            clone.SetActive(true);
            //assigning the proper map icon to the gam object that dropped
            SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
            mapIcon.sprite = itemArmor.MapIcon;
            PlayerStats.curWeight -= itemArmor.Weight;
            Inventory._desc.text = " ";
            Inventory._name.text = " ";
            Inventory._image.sprite = null;
            for (int i = 0; i < InventoryList.itemList.Count; i++)
            {
                if (InventoryList.itemList[i] == gameObject)
                {
                    //removing the dybbuk shop item of the same type from the sell list
                    GameObject shopItem = InventoryList.sellList[i];
                    InventoryList.sellList.Remove(shopItem);
                    Destroy(shopItem);

                    //removing the item from the inventory list
                    InventoryList.itemList.Remove(gameObject);
                    Destroy(gameObject);
                    if (InventoryList.itemList.Count > 0)
                    {
                        if (i != InventoryList.itemList.Count)
                            UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i]);
                        else
                            UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i - 1]);
                        if (i > InventoryList.itemList.Count - 3 && i > 2)
                            UI.inventoryContent.transform.localPosition = new Vector3(UI.inventoryContent.transform.localPosition.x, -InventoryList.itemList[InventoryList.itemList.Count - 3].transform.localPosition.y, UI.inventoryContent.transform.localPosition.z);
                        i = InventoryList.itemList.Count;
                    }
                }//end of if
            }//end of forloop
        }
    }
    public void pickedUpArmor(BaseArmor myArmor)
    {
        itemArmor = myArmor;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemArmor.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemArmor.ItemName;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = itemArmor.ItemDesc;
        Inventory._name.text = itemArmor.ItemName;
        Inventory._image.sprite = itemArmor.Icon;
        //checking to see what inventory item (index) was selected to decide whether or not we want the
        //inventory to change transforms based on the iem selected
        for (int i = 0; i < InventoryList.itemList.Count; i++)
        {
            if (InventoryList.itemList[i] == gameObject)
            {
                if (i > 2 && i < InventoryList.itemList.Count - 3)
                    UI.inventoryContent.transform.localPosition = new Vector3(UI.inventoryContent.transform.localPosition.x, -transform.localPosition.y, UI.inventoryContent.transform.localPosition.z);
                i = InventoryList.itemList.Count;
            }
        }
        InventorySounds.select.Play();
    }
}
