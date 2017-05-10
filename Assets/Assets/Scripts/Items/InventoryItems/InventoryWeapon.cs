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
            itemWeapon = gameObject.GetComponent<CreateNewWeapon>().NewWeapon;
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
            GameObject clone;
            clone = Instantiate(droppedWeapon, Controls._Player.transform.position, transform.rotation) as GameObject;
            clone.GetComponent<DroppedWeapon>().DropWeapon(itemWeapon);
            InventoryList.itemList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
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
        Inventory._image = itemWeapon.Icon;

        Inventory.rlBar.transform.localScale = new Vector3(itemWeapon.ReloadLvl / 5, 1, 1);
        Inventory.frBar.transform.localScale = new Vector3(itemWeapon.ReloadLvl / 5, 1, 1);
        Inventory.dmgBar.transform.localScale = new Vector3(itemWeapon.FireRateLvl / 5, 1, 1);
        Inventory.ccBar.transform.localScale = new Vector3(itemWeapon.DamageLvl / 5, 1, 1);
        Inventory.cdBar.transform.localScale = new Vector3(itemWeapon.CapacityLvl / 5, 1, 1);
        Inventory.accBar.transform.localScale = new Vector3(itemWeapon.CriticalChanceLvl / 5, 1, 1);
        Inventory.capBar.transform.localScale = new Vector3(itemWeapon.CriticalDamageLvl / 5, 1, 1);
        Inventory.inventoryContent.transform.localPosition = new Vector3(Inventory.inventoryContent.transform.localPosition.x, -transform.localPosition.y, Inventory.inventoryContent.transform.localPosition.z);
    }
}
