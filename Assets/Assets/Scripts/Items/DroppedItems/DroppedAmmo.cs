using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedAmmo : MonoBehaviour
{
    public GameObject inventoryAmmoPrefab;
    BaseAmmo dropAmmo = new BaseAmmo();

    public void DropAmmo(BaseAmmo myAmmo)
    {
        dropAmmo = myAmmo;
        gameObject.GetComponent<AmmoDisplay>().myText.text = dropAmmo.AmmoTypes.ToString();
    }

    public void PickedUp()
    {
        switch(dropAmmo.AmmoTypes)
        {
            default://picking up handgun ammo
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.hgAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.hgAmmo > 0)
                    {
                        PlayerStats.hgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.hgAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.hgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.hgAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.ShotgunShells:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.sgAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.sgAmmo > 0)
                    {
                        PlayerStats.sgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.sgAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.sgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.sgAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.RifleAmmo:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.rifleAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.rifleAmmo > 0)
                    {
                        PlayerStats.rifleAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.rifleAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.rifleAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.rifleAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.AssaultRifleAmmo:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.arAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.arAmmo > 0)
                    {
                        PlayerStats.arAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.arAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.arAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.arAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.MachinegunAmmo:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.mgAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.mgAmmo > 0)
                    {
                        PlayerStats.mgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.mgAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.mgAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.mgAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.MagnumAmmo:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.magnumAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.magnumAmmo > 0)
                    {
                        PlayerStats.magnumAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.magnumAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.magnumAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.magnumAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
            case BaseAmmo.AmmoType.ExplosiveRounds:
                if (PlayerStats.curWeight + (dropAmmo.Quantity * PlayerStats.explosiveAmmoWeight) <= PlayerStats.maxWeight)
                {
                    StartCoroutine(ItemObtained(dropAmmo.Quantity));
                    if (PlayerStats.explosiveAmmo > 0)
                    {
                        PlayerStats.explosiveAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.explosiveAmmoWeight;
                        dropAmmo.Quantity = 0;
                    }
                    else
                    {
                        PlayerStats.explosiveAmmo += dropAmmo.Quantity;
                        PlayerStats.curWeight += dropAmmo.Quantity * PlayerStats.explosiveAmmoWeight;
                        GameObject clone;
                        clone = Instantiate(inventoryAmmoPrefab, UI.inventoryContent.transform.position, transform.rotation) as GameObject;
                        clone.transform.SetParent(UI.inventoryContent.transform, true);
                        clone.transform.localScale = new Vector3(1, 1, 1);
                        clone.GetComponent<InventoryAmmo>().PickedUpAmmo(dropAmmo);
                        clone.SetActive(true);
                        InventoryList.itemList.Add(clone);
                        dropAmmo.Quantity = 0;
                    }
                }
                else
                {
                    StartCoroutine(NoStrength());
                }
                break;
        }
    }

    public BaseAmmo AmmoStats
    {
        get { return dropAmmo; }
        set { dropAmmo = value; }
    }

    IEnumerator ItemObtained(int ammoCount)
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropAmmo.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You've obtained the "+ ammoCount +" "+dropAmmo.ItemName+".";
        GameManagerScript.itemInfoText.text = GameManagerScript.itemInfoText.text.Replace(dropAmmo.ItemName.ToString(), "<color=#FFFFFFFF>" + dropAmmo.ItemName.ToString() + "</color>");
        GameManagerScript.stat.gameObject.SetActive(false);
        Time.timeScale = 0;
        AmmoDisplay.isActive = false;
        Destroy(gameObject);
    }

    IEnumerator NoStrength()
    {
        yield return new WaitForSeconds(.016f);
        GameManagerScript.itemInfoImage.sprite = dropAmmo.Icon;
        GameManagerScript.itemInfo.SetActive(true);
        GameManagerScript.itemInfoText.text = "You haven't enough strength to carry any further items.";
        AmmoDisplay.isActive = false;
        //  GameManagerScript.stat.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
