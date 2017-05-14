using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMisc : MonoBehaviour
{
    private BaseMisc itemMisc;
    public GameObject droppedMisc;

    private void Start()
    {
        if (gameObject.GetComponent<CreateNewMisc>())
        {
            CreateNewMisc m = gameObject.GetComponent<CreateNewMisc>();
            itemMisc = m.NewMisc;
            Destroy(m);
        }
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemMisc.ItemName;
    }

    public void DroppedMisc()
    {
        if (Input.GetKeyDown("return"))
        {
                GameObject clone;
                Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                clone = Instantiate(droppedMisc, pos, transform.rotation) as GameObject;
                clone.GetComponent<DroppedMisc>().DropMisc(itemMisc);
                clone.SetActive(true);
                for (int i = 0; i < InventoryList.itemList.Count; i++)
                {
                    if (InventoryList.itemList[i] == gameObject)
                    {
                        InventoryList.itemList.Remove(gameObject);
                        Destroy(gameObject);
                        if (InventoryList.itemList.Count > 0)
                        {
                            if (i != InventoryList.itemList.Count)
                                InventoryList.eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(InventoryList.itemList[i]);
                            else
                                InventoryList.eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(InventoryList.itemList[i - 1]);
                            i = InventoryList.itemList.Count;
                        }
                    }//end of if
                }//end of forloop
                 //   print(InventoryList.itemList.Count);
        }//end of input
    }//end of function
    public void pickedUpMisc(BaseMisc myMisc)
    {
        itemMisc = myMisc;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemMisc.ItemName.ToString();
        // itemMisc.Quantity = 0;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = itemMisc.ItemDesc;
        Inventory._name.text = itemMisc.ItemName;
        Inventory._image = itemMisc.Icon;
        Inventory.inventoryContent.transform.localPosition = new Vector3(Inventory.inventoryContent.transform.localPosition.x, -transform.localPosition.y, Inventory.inventoryContent.transform.localPosition.z);
    }
}
