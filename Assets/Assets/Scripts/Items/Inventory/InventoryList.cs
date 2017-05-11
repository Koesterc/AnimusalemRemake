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
    public static int index;

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
            }
            if (r.GetComponent<InventoryArmor>())
            {
                r.gameObject.AddComponent<CreateNewArmor>();
                CreateNewArmor ca = r.GetComponent<CreateNewArmor>();
                ca.CreateArmor();
            }
            if (r.GetComponent<InventoryMisc>())
            {
                r.gameObject.AddComponent<CreateNewMisc>();
                CreateNewMisc cm = r.GetComponent<CreateNewMisc>();
                cm.CreateMisc();
            }
            index = 0;
            StartCoroutine (Wait());
        }
    }

    void OnEnable()
    {
        index = 0;
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.06f);
        InventoryList.eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(InventoryList.itemList[0]);
        scrollBar.value = 1;
    }
}
