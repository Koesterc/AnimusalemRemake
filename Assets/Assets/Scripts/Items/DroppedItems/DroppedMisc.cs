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
        if ((PlayerStats.curWeight + dropMisc.Weight) <= PlayerStats.maxWeight)
        {
            GameObject clone;
            clone = Instantiate(inventoryMiscPrefab, Inventory.inventoryContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(Inventory.inventoryContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.GetComponent<InventoryMisc>().pickedUpMisc(dropMisc);
            clone.SetActive(true);
            InventoryList.itemList.Add(clone.gameObject);
            PlayerStats.curWeight += dropMisc.Weight;
            StartCoroutine(ItemObtained());
        }
        else
            StartCoroutine(NoStrength());

    }
    IEnumerator ItemObtained()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropMisc.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You've obtained the " + dropMisc.ItemName + ".";
        GameManagerScript.itemInfoText.text = GameManagerScript.itemInfoText.text.Replace(dropMisc.ItemName.ToString(), "<color=#FFFFFFFF>" + dropMisc.ItemName.ToString() + "</color>");
        GameManagerScript.stat.gameObject.SetActive(false);
        Time.timeScale = 0;
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropMisc.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        GameManagerScript.stat.gameObject.SetActive(false);
        Time.timeScale = 0;

        Destroy(gameObject);
    }
}
