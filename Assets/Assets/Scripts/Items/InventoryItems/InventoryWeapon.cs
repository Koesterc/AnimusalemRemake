using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapon : MonoBehaviour
{
    private BaseWeapon itemWeapon;
    public GameObject droppedWeapon;

    private void Start()
    {
        if (gameObject.GetComponent<CreateNewWeapon>())
        {
            CreateNewWeapon c = gameObject.GetComponent<CreateNewWeapon>();
            itemWeapon = c.NewWeapon;
            Destroy(c);
        }
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemWeapon.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemWeapon.WeaponTypes.ToString();
    } 

    public void DroppedWeapon()
    {
        if (Input.GetKeyDown("return"))
        {
            InventorySounds.drop.Play();//playing the sound
            GameObject clone;
            Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
            clone = Instantiate(droppedWeapon, pos, transform.rotation) as GameObject;
            clone.GetComponent<DroppedWeapon>().DropWeapon(itemWeapon);
            clone.SetActive(true);
            //assigning the proper map icon to the gam object that dropped
            SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
            mapIcon.sprite = itemWeapon.MapIcon;
            PlayerStats.curWeight -= itemWeapon.Weight;
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
                    InventoryList.weaponList.Remove(gameObject);
                    Destroy(gameObject);
                    if (InventoryList.itemList.Count > 0)
                    {
                        if (i != InventoryList.itemList.Count)
                            UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i]);
                        else
                            UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i-1]);
                        i = InventoryList.itemList.Count;
                    }//end of if
                }//end of if
            }//end of forloop
        }//end of input
    }//end of class
    public void pickedUpWeapon(BaseWeapon myWeapon)
    {
        itemWeapon = myWeapon;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemWeapon.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemWeapon.ItemName;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = itemWeapon.ItemDesc;
        Inventory._name.text = itemWeapon.ItemName;
        Inventory._image.sprite = itemWeapon.Icon;

        Inventory.rlBar.transform.localScale = new Vector3(itemWeapon.ReloadLvl / 5, 1, 1);
        Inventory.frBar.transform.localScale = new Vector3(itemWeapon.ReloadLvl / 5, 1, 1);
        Inventory.dmgBar.transform.localScale = new Vector3(itemWeapon.FireRateLvl / 5, 1, 1);
        Inventory.ccBar.transform.localScale = new Vector3(itemWeapon.DamageLvl / 5, 1, 1);
        Inventory.cdBar.transform.localScale = new Vector3(itemWeapon.CapacityLvl / 5, 1, 1);
        Inventory.accBar.transform.localScale = new Vector3(itemWeapon.CriticalChanceLvl / 5, 1, 1);
        Inventory.capBar.transform.localScale = new Vector3(itemWeapon.CriticalDamageLvl / 5, 1, 1);
        UI.inventoryContent.transform.localPosition = new Vector3(UI.inventoryContent.transform.localPosition.x, -transform.localPosition.y, UI.inventoryContent.transform.localPosition.z);

        InventorySounds.select.Play();
    }
}
