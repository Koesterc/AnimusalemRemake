﻿using System.Collections;
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
    }

    public void DroppedAmmo()
    {
        if (Input.GetKeyDown("return"))
        {
            switch (itemAmmo.AmmoTypes)
            {//handgun ammo
                case BaseAmmo.AmmoType.HandgunAmmo:
                    if (PlayerStats.hgAmmo > 5)
                    {
                        PlayerStats.hgAmmo -= 5;
                        itemAmmo.Quantity += 5;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.hgAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.hgAmmo;
                        PlayerStats.hgAmmo -= PlayerStats.hgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//shotgun ammo
                case BaseAmmo.AmmoType.ShotgunShells:
                    if (PlayerStats.sgAmmo > 2)
                    {
                        PlayerStats.sgAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.sgAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.sgAmmo;
                        PlayerStats.sgAmmo -= PlayerStats.sgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//rifle ammo
                case BaseAmmo.AmmoType.RifleAmmo:
                    if (PlayerStats.rifleAmmo > 2)
                    {
                        PlayerStats.rifleAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.rifleAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.rifleAmmo;
                        PlayerStats.rifleAmmo -= PlayerStats.rifleAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//machinegnun ammo
                case BaseAmmo.AmmoType.MachinegunAmmo:
                    if (PlayerStats.mgAmmo > 10)
                    {
                        PlayerStats.mgAmmo -= 10;
                        itemAmmo.Quantity += 10;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.mgAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.mgAmmo;
                        PlayerStats.mgAmmo -= PlayerStats.mgAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//rifle ammo
                case BaseAmmo.AmmoType.AssaultRifleAmmo:
                    if (PlayerStats.arAmmo > 5)
                    {
                        PlayerStats.arAmmo -= 5;
                        itemAmmo.Quantity += 5;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.arAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.arAmmo;
                        PlayerStats.arAmmo -= PlayerStats.arAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//magnum ammo
                case BaseAmmo.AmmoType.MagnumAmmo:
                    if (PlayerStats.magnumAmmo > 1)
                    {
                        PlayerStats.magnumAmmo -= 2;
                        itemAmmo.Quantity += 2;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.magnumAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.magnumAmmo;
                        PlayerStats.magnumAmmo -= PlayerStats.magnumAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;//explosive ammo
                case BaseAmmo.AmmoType.ExplosiveRounds:
                    if (PlayerStats.explosiveAmmo > 1)
                    {
                        PlayerStats.explosiveAmmo -= 1;
                        itemAmmo.Quantity += 1;
                        Transform _weight = gameObject.transform.Find("Weight");
                        Transform _name = gameObject.transform.Find("Type");
                        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
                        _name.GetComponent<Text>().text = itemAmmo.ItemName + "(" + PlayerStats.explosiveAmmo + ")";
                    }
                    else
                    {
                        itemAmmo.Quantity += PlayerStats.explosiveAmmo;
                        PlayerStats.explosiveAmmo -= PlayerStats.explosiveAmmo;
                        GameObject clone;
                        Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
                        clone = Instantiate(droppedAmmo, pos, transform.rotation) as GameObject;
                        clone.GetComponent<DroppedAmmo>().DropAmmo(itemAmmo);
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
                    }
                    break;
            }//end of switch
        }//end of input
    }//end of function


    public void pickedUpMisc(BaseAmmo myAmmo)
    {
        itemAmmo = myAmmo;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemAmmo.Weight.ToString() + " lbs";
        if (itemAmmo.AmmoTypes == BaseAmmo.AmmoType.AssaultRifleAmmo || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.MachinegunAmmo || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.HandgunAmmo || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.ShotgunShells || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.MagnumAmmo || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.ExplosiveRounds || itemAmmo.AmmoTypes == BaseAmmo.AmmoType.RifleAmmo)
        {
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
            // itemAmmo.Quantity = 0;
        }
        else
            _name.GetComponent<Text>().text = itemAmmo.ItemName;
        itemAmmo.Quantity = 0;
    }


    public void UpdateSelection()
    {
        Inventory._desc.text = itemAmmo.ItemDesc;
        Inventory._name.text = itemAmmo.ItemName;
        Inventory._image = itemAmmo.Icon;
        Inventory.inventoryContent.transform.localPosition = new Vector3(Inventory.inventoryContent.transform.localPosition.x, -transform.localPosition.y, Inventory.inventoryContent.transform.localPosition.z);
    }
}
