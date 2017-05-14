using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedMisc : MonoBehaviour
{
    public GameObject inventoryMiscPrefab;
    BaseMisc dropMisc = new BaseMisc();

    void start()
    {
        if (gameObject.GetComponent<CreateNewMisc>())
        {
            CreateNewMisc m = gameObject.GetComponent<CreateNewMisc>();
            dropMisc = m.NewMisc;
            Destroy(m);
        }
    }

    public void DropMisc(BaseMisc myMisc)
    {
        dropMisc = myMisc;
        gameObject.GetComponent<ItemDisplay>().myText.text = dropMisc.MiscTypes.ToString();
        //subtract player's weight
    }
    public BaseMisc MiscStats
    {
        get { return dropMisc; }
    }

    public void PickedUp()
    {
      GameObject clone;
      clone = Instantiate(inventoryMiscPrefab, Inventory.inventoryContent.transform.position, transform.rotation) as GameObject;
      clone.transform.SetParent(Inventory.inventoryContent.transform, true);
      clone.transform.localScale = new Vector3(1, 1, 1);
      clone.GetComponent<InventoryMisc>().pickedUpMisc(dropMisc);
      clone.SetActive(true);
      InventoryList.itemList.Add(clone.gameObject);
      Destroy(gameObject);
    }

}
