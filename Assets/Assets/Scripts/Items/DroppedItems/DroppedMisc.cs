using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppedMisc : MonoBehaviour
{
    public GameObject inventoryMiscPrefab;
    BaseMisc dropMisc = new BaseMisc();
    [SerializeField]
    GameObject shopMiscPrefab;

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
        gameObject.GetComponent<MiscDisplay>().myText.text = dropMisc.MiscTypes.ToString();
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
            clone = Instantiate(inventoryMiscPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.inventoryContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.GetComponent<InventoryMisc>().pickedUpMisc(dropMisc);
            clone.SetActive(true);
            InventoryList.itemList.Add(clone);
            PlayerStats.curWeight += dropMisc.Weight;
            StartCoroutine(ItemObtained());

            ////adding the gameobject to the sell list
            clone = Instantiate(shopMiscPrefab, UI.sellContent.transform.position, transform.rotation) as GameObject;
            clone.transform.SetParent(UI.sellContent.transform, true);
            clone.transform.localScale = new Vector3(1, 1, 1);
            //transfering the data
            clone.gameObject.GetComponent<DybbukMisc>().TransferData(dropMisc);
            clone.transform.FindChild("Value").GetComponent<Text>().text = "$" + clone.gameObject.GetComponent<DybbukMisc>().ShopMisc.SellValue.ToString("n0");
            clone.transform.FindChild("Name").GetComponent<Text>().text = clone.gameObject.GetComponent<DybbukMisc>().ShopMisc.ItemName.ToString();
            clone.transform.FindChild("Level").GetComponent<Text>().text = " ";
            clone.SetActive(true);
            InventoryList.sellList.Add(clone);
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
        Time.timeScale = 0;
        AmmoDisplay.isActive = false;
        GameManagerScript.stat.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropMisc.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        Time.timeScale = 0;
        gameObject.GetComponent<MiscDisplay>().pickUp = true;
    }
}
