using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour
{
    public static List<GameObject> itemList = new List<GameObject>();
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
            }
            else if (r.GetComponent<InventoryArmor>())
            {
                r.gameObject.AddComponent<CreateNewArmor>();
                CreateNewArmor ca = r.GetComponent<CreateNewArmor>();
                ca.CreateArmor();
                r.gameObject.SetActive(true);
            }
            else if (r.GetComponent<InventoryMisc>())
            {
                r.gameObject.AddComponent<CreateNewMisc>();
                CreateNewMisc cm = r.GetComponent<CreateNewMisc>();
                cm.CreateMisc();
                r.gameObject.SetActive(true);
            }
            else if (r.GetComponent<InventoryAmmo>())
            {
                r.gameObject.AddComponent<CreateNewAmmo>();
                CreateNewAmmo a = r.GetComponent<CreateNewAmmo>();
                a.CreateAmmo();
                r.gameObject.SetActive(true);
            }

        }
    }

    void OnEnable()
    {
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
            yield return new WaitForSeconds(.06f);
            UI.UIevent.SetSelectedGameObject(itemList[0]);
        }
    }
}
