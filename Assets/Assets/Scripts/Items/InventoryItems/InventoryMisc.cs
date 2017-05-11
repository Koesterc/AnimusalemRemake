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
            CreateNewMisc c = gameObject.GetComponent<CreateNewMisc>();
            itemMisc = gameObject.GetComponent<CreateNewMisc>().NewMisc;
            Destroy(c);
        }
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemMisc.ItemName;
    }

    public void CreateMisc()
    {
        itemMisc = new BaseMisc();
        itemMisc.ItemID = Random.Range(0, 10000);
        ChooseMiscType();

    }

    private void ChooseMiscType()
    {
        int temp = Random.Range(0, 13);

        switch (temp)
        {
            default:
                itemMisc.MiscTypes = BaseMisc.MiscType.SmallAid;
                //assigning the name
                itemMisc.ItemName = "Small Aid";
                itemMisc.ItemDesc = "A small bottle of medical ointment. There's just enough to treat a minor wound.";
                itemMisc.Weight = 1f;
                break;
            case 1:
                itemMisc.MiscTypes = BaseMisc.MiscType.MediumAid;
                //assigning the name
                itemMisc.ItemName = "Medium Aid";
                itemMisc.ItemDesc = "A well supplied kit with various items essential to treat moderate injuries.";
                itemMisc.Weight = 2f;
                break;
            case 2:
                itemMisc.MiscTypes = BaseMisc.MiscType.LargeAid;
                //assigning the name
                itemMisc.ItemName = "Large Aid";
                itemMisc.ItemDesc = "An imeasurable supply of medical equipment used to treat serious lacerations.";
                itemMisc.Weight = 3f;
                break;
            case 3:
                itemMisc.MiscTypes = BaseMisc.MiscType.PainKiller;
                //assigning the name
                itemMisc.ItemName = "Pain Killer";
                itemMisc.ItemDesc = "Reduces the amount of injury one takes while in battle.";
                itemMisc.Weight = 1f;
                break;
            case 4:
                itemMisc.MiscTypes = BaseMisc.MiscType.HolyWater;
                //assigning the name
                itemMisc.ItemName = "Holy Water";
                itemMisc.ItemDesc = "A small portion of blessed water. Mainly, it can be used to avoid unwanted attention.";
                itemMisc.Weight = 1f;
                break;
            case 5:
                itemMisc.MiscTypes = BaseMisc.MiscType.DreamCatcher;
                //assigning the name
                itemMisc.ItemName = "Dream Catcher";
                itemMisc.ItemDesc = "Although it is typically used to avoid bad dreams, this item can be used in battle to avoid a bad situation.";
                itemMisc.Weight = 1f;
                break;
            case 6:
                itemMisc.MiscTypes = BaseMisc.MiscType.HandgunAmmo;
                //assigning the name
                itemMisc.ItemName = "Handgun Bullets";
                itemMisc.ItemDesc = "9mm handgun bullets.";
                itemMisc.Quanntity = Random.Range(5, 15);
                itemMisc.Weight = 1f;
                break;
            case 7:
                itemMisc.MiscTypes = BaseMisc.MiscType.ShotgunShells;
                //assigning the name
                itemMisc.ItemName = "12 gauge shells";
                itemMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                itemMisc.Quanntity = Random.Range(1, 3);
                itemMisc.Weight = 1f;
                break;
            case 8:
                itemMisc.MiscTypes = BaseMisc.MiscType.RifleAmmo;
                //assigning the name
                itemMisc.ItemName = "Rifle Rounds";
                itemMisc.ItemDesc = "30 caliber rounds.";
                itemMisc.Quanntity = Random.Range(1, 5);
                itemMisc.Weight = 1f;
                break;
            case 9:
                itemMisc.MiscTypes = BaseMisc.MiscType.MachinegunAmmo;
                //assigning the name
                itemMisc.ItemName = "Machinegun Bullets";
                itemMisc.ItemDesc = ".40 carbine bullets.";
                itemMisc.Quanntity = Random.Range(5, 20);
                itemMisc.Weight = 1f;
                break;
            case 10:
                itemMisc.MiscTypes = BaseMisc.MiscType.AssaultRifleAmmo;
                //assigning the name
                itemMisc.ItemName = "Assault Rifle Ammunition";
                itemMisc.ItemDesc = "5.56 NATO rounds.";
                itemMisc.Quanntity = Random.Range(5, 15);
                itemMisc.Weight = 1f;
                break;
            case 11:
                itemMisc.MiscTypes = BaseMisc.MiscType.MagnumAmmo;
                //assigning the name
                itemMisc.ItemName = "Magnum Rounds";
                itemMisc.ItemDesc = ".357 magnum rounds.";
                itemMisc.Quanntity = Random.Range(1, 2);
                itemMisc.Weight = 1f;
                break;
            case 12:
                itemMisc.MiscTypes = BaseMisc.MiscType.ExplosiveRounds;
                //assigning the name
                itemMisc.ItemName = "Explosive Rounds";
                itemMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                itemMisc.Quanntity = 1;
                itemMisc.Weight = 1f;
                break;
            case 13:
                itemMisc.MiscTypes = BaseMisc.MiscType.OldKey;
                //assigning the name
                itemMisc.ItemName = "Old Key";
                itemMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                itemMisc.Weight = 1f;
                break;
        }
    }
    public void DroppedMisc()
    {
        if (Input.GetKeyDown("return"))
        {
            GameObject clone;
            Vector3 pos = new Vector3(Random.Range(Controls._Player.transform.position.x - 1.5f, Controls._Player.transform.position.x + 1.5f), Controls._Player.transform.position.y, Random.Range(Controls._Player.transform.position.z - 1.5f, Controls._Player.transform.position.z + 1.5f));
            clone = Instantiate(droppedMisc, pos, transform.rotation) as GameObject;
            clone.GetComponent<DroppedMisc>().DropMisc(itemMisc);
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
    }
    public void pickedUpMisc(BaseMisc myMisc)
    {
        itemMisc = myMisc;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = itemMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = itemMisc.ItemName;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = itemMisc.ItemDesc;
        Inventory._name.text = itemMisc.ItemName;
        Inventory._image = itemMisc.Icon;
        Inventory.inventoryContent.transform.localPosition = new Vector3(Inventory.inventoryContent.transform.localPosition.x, -transform.localPosition.y, Inventory.inventoryContent.transform.localPosition.z);
    }
}
