using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedWeapon : MonoBehaviour
{
    public GameObject inventoryWeaponPrefab;
    BaseWeapon dropWeapon = new BaseWeapon();
    [SerializeField]
    GameObject shopWeaponPrefab;

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

            //creating the same game object for the player in the sell list
            clone = Instantiate(shopWeaponPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.sellContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            //transfering the data
            clone.gameObject.GetComponent<DybbukWeapon>().TransferData(dropWeapon);
            clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.SellValue.ToString("n0");
            clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.ItemName.ToString();
            clone.transform.FindChild("Level").GetComponent<Text>().text = "Level: " + clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.LevelRestriction.ToString();
            clone.SetActive(true);
            InventoryList.sellList.Add(clone);
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
        PlayerStats.curWeight += dropWeapon.Weight;
        Time.timeScale = 0;
        AmmoDisplay.isActive = false;
        GameManagerScript.stat.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropWeapon.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        Time.timeScale = 0;
        gameObject.GetComponent<WeaponDisplay>().pickUp = true;
    }
}
