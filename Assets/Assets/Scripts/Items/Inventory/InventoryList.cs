using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour
{
    [Header("These are prefabs (Prefabs > Items > Shop)")]
    [SerializeField]
    GameObject shopWeaponPrefab;
    [SerializeField]
    GameObject shopArmorPrefab;
    [SerializeField]
    GameObject shopMiscPrefab;
    [SerializeField]
    GameObject shopAmmoPrefab;

    public static List<GameObject> itemList = new List<GameObject>();
    public static List<GameObject> sellList = new List<GameObject>();
    public static Scrollbar scrollBar;
    //used for the shop list
    public static List<GameObject> weaponList = new List<GameObject>();

    void Awake()
    {
        scrollBar = GameObject.Find("Canvas/Inventory/Scrollbar").GetComponent<Scrollbar>();
      //  Inventory.weightText.text = "Weight: " +PlayerStats.curWeight.ToString() + "/" + PlayerStats.maxWeight.ToString() + "(" + ((PlayerStats.curWeight / PlayerStats.maxWeight)*100).ToString() + "%" + ")";
      //  Inventory.healthText.text = "Health: " + PlayerStats.health.ToString() + "/" + PlayerStats.maxHealth.ToString() + "(" + ((PlayerStats.health / PlayerStats.maxHealth)*100).ToString() + "%" + ")";
        foreach (Transform r in UI.inventoryContent.transform)
        {
            itemList.Add(r.gameObject);
            if (r.GetComponent<InventoryWeapon>())
            {
                r.gameObject.AddComponent<CreateNewWeapon>();
                CreateNewWeapon cw = r.GetComponent<CreateNewWeapon>();
                cw.CreateWeapon();
                r.gameObject.SetActive(true);

                //adding the gameobject to the sell list
                GameObject clone;
                clone = Instantiate(shopWeaponPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(UI.sellContent.transform, true);
                clone.transform.localScale = new Vector3(1, 1, 1);
                //transfering the data
                clone.gameObject.GetComponent<DybbukWeapon>().TransferData(cw.NewWeapon);
                clone.transform.FindChild("Value").GetComponent<Text>().text = "$"+clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.SellValue.ToString("n0");
                clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.ItemName.ToString();
                clone.transform.FindChild("Level").GetComponent<Text>().text = "Level: "+clone.gameObject.GetComponent<DybbukWeapon>().ShopWeapon.LevelRestriction.ToString();
                clone.SetActive(true);
                sellList.Add(clone);
            }
            else if (r.GetComponent<InventoryArmor>())
            {
                r.gameObject.AddComponent<CreateNewArmor>();
                CreateNewArmor ca = r.GetComponent<CreateNewArmor>();
                ca.CreateArmor();
                r.gameObject.SetActive(true);

                ////adding the gameobject to the sell list
                GameObject clone;
                clone = Instantiate(shopArmorPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(UI.sellContent.transform, true);
                clone.transform.localScale = new Vector3(1, 1, 1);
                //transfering the data
                clone.gameObject.GetComponent<DybbukArmor>().TransferData(ca.NewArmor);
                clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.SellValue.ToString("n0");
                clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.ItemName.ToString();
                clone.transform.FindChild("Level").GetComponent<Text>().text = "Level: " + clone.gameObject.GetComponent<DybbukArmor>().ShopArmor.LevelRestriction.ToString();
                clone.SetActive(true);
                sellList.Add(clone);
            }
            else if (r.GetComponent<InventoryMisc>())
            {
                r.gameObject.AddComponent<CreateNewMisc>();
                CreateNewMisc cm = r.GetComponent<CreateNewMisc>();
                cm.CreateMisc();
                r.gameObject.SetActive(true);

                ////adding the gameobject to the sell list
                GameObject clone;
                clone = Instantiate(shopMiscPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(UI.sellContent.transform, true);
                clone.transform.localScale = new Vector3(1, 1, 1);
                //transfering the data
                clone.gameObject.GetComponent<DybbukMisc>().TransferData(cm.NewMisc);
                clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukMisc>().ShopMisc.SellValue.ToString("n0");
                clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukMisc>().ShopMisc.ItemName.ToString();
                clone.transform.FindChild("Level").GetComponent<Text>().text = " ";
                clone.SetActive(true);
                sellList.Add(clone);
            }
            else if (r.GetComponent<InventoryAmmo>())
            {
                r.gameObject.AddComponent<CreateNewAmmo>();
                CreateNewAmmo a = r.GetComponent<CreateNewAmmo>();
                a.CreateAmmo();
                r.gameObject.SetActive(true);

                ////adding the gameobject to the sell list
                GameObject clone;
                clone = Instantiate(shopAmmoPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
                clone.transform.SetParent(UI.sellContent.transform, true);
                clone.transform.localScale = new Vector3(1, 1, 1);
                //transfering the data
                clone.gameObject.GetComponent<DybbukAmmo>().TransferData(a.NewAmmo);
                clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukAmmo>().ShopAmmo.SellValue.ToString("n0");
                clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukAmmo>().ShopAmmo.ItemName.ToString();
                clone.transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + clone.gameObject.GetComponent<DybbukAmmo>().ShopAmmo.Quantity.ToString();
                clone.SetActive(true);
                sellList.Add(clone);
            }
        }
    }

    void OnEnable()
    {
        if (itemList.Count > 0)
            StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        scrollBar.value = 1;
        UI.UIevent.SetSelectedGameObject(null);
        yield return new WaitForSeconds(.06f);
        if (UI.UIevent.currentSelectedGameObject == null)
            UI.UIevent.SetSelectedGameObject(itemList[0]);
        else
        {
            yield return new WaitForSeconds(.1f);
            UI.UIevent.SetSelectedGameObject(itemList[0]);
        }
    }
}
