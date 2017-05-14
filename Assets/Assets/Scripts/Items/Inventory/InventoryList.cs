using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryList : MonoBehaviour
{
    public static GameObject eventSystem;
    //public static Dictionary<string,GameObject> itemList = new Dictionary<string,GameObject>();
    public static List<GameObject> itemList = new List<GameObject>();
    public static Scrollbar scrollBar;

    void Awake()
    {
        eventSystem = GameObject.Find("Canvas/EventSystem");
        scrollBar = GameObject.Find("Canvas/Inventory/Scrollbar").GetComponent<Scrollbar>();
        foreach (Transform r in Inventory.inventoryContent.transform)
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
            StartCoroutine (Wait());
        }
    }

    void OnEnable()
    {
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.06f);
        try
        {
            eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(itemList[0]);
        }
        catch
        {

        }
        scrollBar.value = 1;
    }
}
