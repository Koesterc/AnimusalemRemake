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
            PlayerStats.curWeight -= itemMisc.Weight;
            Inventory._drop.Play();//playing the sound
            GameObject clone;
            Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
            clone = Instantiate(droppedMisc, pos, transform.rotation) as GameObject;
            clone.GetComponent<DroppedMisc>().DropMisc(itemMisc);
            clone.SetActive(true);
            //assigning the proper map icon to the gam object that dropped
            SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
            mapIcon.sprite = itemMisc.MapIcon;
            Inventory._desc.text = " ";
            Inventory._name.text = " ";
            Inventory._image.sprite = null;
            for (int i = 0; i < InventoryList.itemList.Count; i++)
                {
                    if (InventoryList.itemList[i] == gameObject)
                    {
                        InventoryList.itemList.Remove(gameObject);
                        Destroy(gameObject);
                        if (InventoryList.itemList.Count > 0)
                        {
                            if (i != InventoryList.itemList.Count)
                                UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i]);
                            else
                                UI.UIevent.SetSelectedGameObject(InventoryList.itemList[i - 1]);
                            i = InventoryList.itemList.Count;
                        }
                    }//end of if
                }//end of forloop
        }//end of input
    }//end of function
    public void pickedUpMisc(BaseMisc myMisc)
    {
        itemMisc = myMisc;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemMisc.ItemName.ToString();
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = itemMisc.ItemDesc;
        Inventory._name.text = itemMisc.ItemName;
        Inventory._image.sprite = itemMisc.Icon;
        UI.inventoryContent.transform.localPosition = new Vector3(UI.inventoryContent.transform.localPosition.x, -transform.localPosition.y, UI.inventoryContent.transform.localPosition.z);

        Inventory._select.Play();
    }
}
