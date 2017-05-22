using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAmmo : MonoBehaviour
{
    private BaseAmmo itemAmmo;
    public GameObject droppedAmmo;

    private void Start()
    {
        if (gameObject.GetComponent<CreateNewAmmo>())
        {
            CreateNewAmmo a = gameObject.GetComponent<CreateNewAmmo>();
            itemAmmo = a.NewAmmo;
            Destroy(a);
        }
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        switch (itemAmmo.AmmoTypes)
        {
            case BaseAmmo.AmmoType.HandgunAmmo:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.hgAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.hgAmmoWeight * PlayerStats.hgAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.ShotgunShells:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.sgAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.sgAmmoWeight * PlayerStats.sgAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.RifleAmmo:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.rifleAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.rifleAmmoWeight * PlayerStats.rifleAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.AssaultRifleAmmo:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.arAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.arAmmoWeight * PlayerStats.arAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.MachinegunAmmo:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.mgAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.mgAmmoWeight * PlayerStats.mgAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.MagnumAmmo:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.magnumAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.magnumAmmoWeight * PlayerStats.magnumAmmo) * 100) / 100).ToString() + " lbs";
                break;
            case BaseAmmo.AmmoType.ExplosiveRounds:
                _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.explosiveAmmo + ")";
                _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.explosiveAmmoWeight * PlayerStats.explosiveAmmo) * 100) / 100).ToString() + " lbs";
                break;
        }
    }

    public void DroppedAmmo()
    {
        if (Input.GetKeyDown("return"))
        {
            InventorySounds.drop.Play();//playing the sound
            switch (itemAmmo.AmmoTypes)
            {//handgun ammo
                case BaseAmmo.AmmoType.HandgunAmmo:
                    if (PlayerStats.hgAmmo > 5)
                    {
                        PlayerStats.hgAmmo -= 5;
                        itemAmmo.Quantity += 5;
                        PlayerStats.curWeight -= (5*PlayerStats.hgAmmoWeight);
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.hgAmmoWeight * PlayerStats.hgAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.hgAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (PlayerStats.hgAmmo * PlayerStats.hgAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.hgAmmo;
                        PlayerStats.hgAmmo -= PlayerStats.hgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = null;
                        Inventory._name.text = null;
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//shotgun ammo
                case BaseAmmo.AmmoType.ShotgunShells:
                    if (PlayerStats.sgAmmo > 2)
                    {
                        PlayerStats.curWeight -= (2 * PlayerStats.sgAmmoWeight);
                        PlayerStats.sgAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.sgAmmoWeight * PlayerStats.sgAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.sgAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (PlayerStats.sgAmmo * PlayerStats.sgAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.sgAmmo;
                        PlayerStats.sgAmmo -= PlayerStats.sgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//rifle ammo
                case BaseAmmo.AmmoType.RifleAmmo:
                    if (PlayerStats.rifleAmmo > 2)
                    {
                        PlayerStats.curWeight -= (2 * PlayerStats.rifleAmmoWeight);
                        PlayerStats.rifleAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.rifleAmmoWeight * PlayerStats.rifleAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.rifleAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (PlayerStats.rifleAmmo * PlayerStats.rifleAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.rifleAmmo;
                        PlayerStats.rifleAmmo -= PlayerStats.rifleAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//machinegnun ammo
                case BaseAmmo.AmmoType.MachinegunAmmo:
                    if (PlayerStats.mgAmmo > 10)
                    {
                        PlayerStats.curWeight -= (10 * PlayerStats.mgAmmoWeight);
                        PlayerStats.mgAmmo -= 10;
                        itemAmmo.Quantity += 10;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.mgAmmoWeight * PlayerStats.mgAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.mgAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (PlayerStats.mgAmmo * PlayerStats.mgAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.mgAmmo;
                        PlayerStats.mgAmmo -= PlayerStats.mgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//rifle ammo
                case BaseAmmo.AmmoType.AssaultRifleAmmo:
                    if (PlayerStats.arAmmo > 5)
                    {
                        PlayerStats.curWeight -= (5 * PlayerStats.arAmmoWeight);
                        PlayerStats.arAmmo -= 5;
                        itemAmmo.Quantity += 5;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.arAmmoWeight * PlayerStats.arAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.arAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (PlayerStats.arAmmo * PlayerStats.arAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.arAmmo;
                        PlayerStats.arAmmo -= PlayerStats.arAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//magnum ammo
                case BaseAmmo.AmmoType.MagnumAmmo:
                    if (PlayerStats.magnumAmmo > 1)
                    {
                        PlayerStats.curWeight -= (1 * PlayerStats.magnumAmmoWeight);
                        PlayerStats.magnumAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.magnumAmmoWeight * PlayerStats.magnumAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.magnumAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (1 * PlayerStats.magnumAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.magnumAmmo;
                        PlayerStats.magnumAmmo -= PlayerStats.magnumAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;//explosive ammo
                case BaseAmmo.AmmoType.ExplosiveRounds:
                    if (PlayerStats.explosiveAmmo > 1)
                    {
                        PlayerStats.curWeight -= (1 * PlayerStats.explosiveAmmoWeight);
                        PlayerStats.explosiveAmmo -= 1;
                        itemAmmo.Quantity += 1;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = (Mathf.Round((PlayerStats.explosiveAmmoWeight * PlayerStats.explosiveAmmo) * 100) / 100).ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.explosiveAmmo + ")";
                    }
                    else
                    {
                        PlayerStats.curWeight -= (1 * PlayerStats.explosiveAmmoWeight);
                        itemAmmo.Quantity += PlayerStats.explosiveAmmo;
                        PlayerStats.explosiveAmmo -= PlayerStats.explosiveAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
                        clone.SetActive(true);
                        //assigning the proper map icon to the gam object that dropped
                        SpriteRenderer mapIcon = clone.transform.Find("MapIcon").gameObject.GetComponent<SpriteRenderer>();
                        mapIcon.sprite = itemAmmo.MapIcon;
                        Inventory._desc.text = " ";
                        Inventory._name.text = " ";
                        Inventory._image.sprite = null;
                        for (int i = 0; i < InventoryList.itemList.Count; i++)
                        {
                            if (InventoryList.itemList[i] == gameObject)
                            {
                                //removing the dybbuk shop item of the same type from the sell list
                                GameObject shopItem = InventoryList.sellList[i];
                                InventoryList.sellList.Remove(shopItem);
                                Destroy(shopItem);

                                //removing the item from the inventory list
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
                    }
                    break;
            }//end of switch
        }//end of input
    }//end of function

    public void PickedUpAmmo(BaseAmmo myAmmo)
    {
        itemAmmo = myAmmo;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
            switch (itemAmmo.AmmoTypes)
            {
                case BaseAmmo.AmmoType.HandgunAmmo:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.hgAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.ShotgunShells:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.sgAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.RifleAmmo:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.rifleAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.AssaultRifleAmmo:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.arAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.MachinegunAmmo:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.mgAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.MagnumAmmo:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.magnumAmmo + ")";
                    break;
                case BaseAmmo.AmmoType.ExplosiveRounds:
                    _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.explosiveAmmo + ")";
                    break;
            }
        itemAmmo.Quantity = 0;
    }


    public void UpdateSelection()
    {
        Inventory._desc.text = itemAmmo.ItemDesc;
        Inventory._name.text = itemAmmo.ItemName;
        Inventory._image.sprite = itemAmmo.Icon;
        UI.inventoryContent.transform.localPosition = new Vector3(UI.inventoryContent.transform.localPosition.x, -transform.localPosition.y, UI.inventoryContent.transform.localPosition.z);
        InventorySounds.select.Play();
    }
}
