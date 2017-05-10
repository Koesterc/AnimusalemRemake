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
            CreateNewArmor c = gameObject.GetComponent<CreateNewArmor>();
            itemArmor= gameObject.GetComponent<CreateNewArmor>().NewArmor;
            Destroy(c);
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
            GameObject clone;
            clone = Instantiate(droppedArmor, Controls._Player.transform.position, transform.rotation) as GameObject;
            clone.GetComponent<DroppedArmor>().DropArmor(itemArmor);
            InventoryList.itemList.Remove(gameObject);
            //  print(InventoryList.itemList.gameObject);
            //     InventoryList.eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(InventoryList.itemList.NextOf(gameObject));

            Destroy(gameObject);
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
        Inventory._image = itemArmor.Icon;
        Inventory.inventoryContent.transform.localPosition = new Vector3(Inventory.inventoryContent.transform.localPosition.x, -transform.localPosition.y, Inventory.inventoryContent.transform.localPosition.z);
    }
}
