using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewMisc : MonoBehaviour
{
    private BaseMisc newMisc;
    public bool isItem;
    public GameObject droppedMisc;
    static bool refresh;

    void Start()
    {
        if (!refresh)
        {
            refresh = true;
            CreateMisc();
            Transform _weight = gameObject.transform.Find("Weight");
            Transform _name = gameObject.transform.Find("Type");
            _weight.GetComponent<Text>().text = newMisc.Weight.ToString() + " lbs";
            _name.GetComponent<Text>().text = newMisc.ItemName;
        }
    }

    private void CreateMisc()
    {
        newMisc = new BaseMisc();
        newMisc.ItemID = Random.Range(0, 10000);
        ChooseMiscType();

    }

    private void ChooseMiscType()
    {
        int temp = Random.Range(0, 13);

        switch (temp)
        {
            default:
                newMisc.MiscTypes = BaseMisc.MiscType.SmallAid;
                //assigning the name
                newMisc.ItemName = "Small Aid";
                newMisc.ItemDesc = "A small bottle of medical ointment. There's just enough to treat a minor wound.";
                newMisc.Weight = 1f;
                break;
            case 1:
                newMisc.MiscTypes = BaseMisc.MiscType.MediumAid;
                //assigning the name
                newMisc.ItemName = "Medium Aid";
                newMisc.ItemDesc = "A well supplied kit with various items essential to treat moderate injuries.";
                newMisc.Weight = 2f;
                break;
            case 2:
                newMisc.MiscTypes = BaseMisc.MiscType.LargeAid;
                //assigning the name
                newMisc.ItemName = "Large Aid";
                newMisc.ItemDesc = "An imeasurable supply of medical equipment used to treat serious lacerations.";
                newMisc.Weight = 3f;
                break;
            case 3:
                newMisc.MiscTypes = BaseMisc.MiscType.PainKiller;
                //assigning the name
                newMisc.ItemName = "Pain Killer";
                newMisc.ItemDesc = "Reduces the amount of injury one takes while in battle.";
                newMisc.Weight = 1f;
                break;
            case 4:
                newMisc.MiscTypes = BaseMisc.MiscType.HolyWater;
                //assigning the name
                newMisc.ItemName = "Holy Water";
                newMisc.ItemDesc = "A small portion of blessed water. Mainly, it can be used to avoid unwanted attention.";
                newMisc.Weight = 1f;
                break;
            case 5:
                newMisc.MiscTypes = BaseMisc.MiscType.DreamCatcher;
                //assigning the name
                newMisc.ItemName = "Dream Catcher";
                newMisc.ItemDesc = "Although it is typically used to avoid bad dreams, this item can be used in battle to avoid a bad situation.";
                newMisc.Weight = 1f;
                break;
            case 6:
                newMisc.MiscTypes = BaseMisc.MiscType.HandgunAmmo;
                //assigning the name
                newMisc.ItemName = "Handgun Bullets";
                newMisc.ItemDesc = "9mm handgun bullets.";
                newMisc.Quanntity = Random.Range(5, 15);
                newMisc.Weight = 1f;
                break;
            case 7:
                newMisc.MiscTypes = BaseMisc.MiscType.ShotgunShells;
                //assigning the name
                newMisc.ItemName = "12 gauge shells";
                newMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                newMisc.Quanntity = Random.Range(1, 3);
                newMisc.Weight = 1f;
                break;
            case 8:
                newMisc.MiscTypes = BaseMisc.MiscType.RifleAmmo;
                //assigning the name
                newMisc.ItemName = "Rifle Rounds";
                newMisc.ItemDesc = "30 caliber rounds.";
                newMisc.Quanntity = Random.Range(1, 5);
                newMisc.Weight = 1f;
                break;
            case 9:
                newMisc.MiscTypes = BaseMisc.MiscType.MachinegunAmmo;
                //assigning the name
                newMisc.ItemName = "Machinegun Bullets";
                newMisc.ItemDesc = ".40 carbine bullets.";
                newMisc.Quanntity = Random.Range(5, 20);
                newMisc.Weight = 1f;
                break;
            case 10:
                newMisc.MiscTypes = BaseMisc.MiscType.AssaultRifleAmmo;
                //assigning the name
                newMisc.ItemName = "Assault Rifle Ammunition";
                newMisc.ItemDesc = "5.56 NATO rounds.";
                newMisc.Quanntity = Random.Range(5, 15);
                newMisc.Weight = 1f;
                break;
            case 11:
                newMisc.MiscTypes = BaseMisc.MiscType.MagnumAmmo;
                //assigning the name
                newMisc.ItemName = "Magnum Rounds";
                newMisc.ItemDesc = ".357 magnum rounds.";
                newMisc.Quanntity = Random.Range(1, 2);
                newMisc.Weight = 1f;
                break;
            case 12:
                newMisc.MiscTypes = BaseMisc.MiscType.ExplosiveRounds;
                //assigning the name
                newMisc.ItemName = "Explosive Rounds";
                newMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                newMisc.Quanntity = 1;
                newMisc.Weight = 1f;
                break;
            case 13:
                newMisc.MiscTypes = BaseMisc.MiscType.OldKey;
                //assigning the name
                newMisc.ItemName = "Old Key";
                newMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                newMisc.Weight = 1f;
                break;
        }
    }
    public void DroppedMisc()
    {
        if (Input.GetKeyDown("return"))
        {
            GameObject clone;
            clone = Instantiate(droppedMisc, Controls._Player.transform.position, transform.rotation) as GameObject;
            clone.GetComponent<DroppedMisc>().DropMisc(newMisc);
            Destroy(gameObject);
        }
    }
    public void pickedUpMisc(BaseMisc myMisc)
    {
        newMisc = myMisc;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = newMisc.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = newMisc.ItemName;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = newMisc.ItemDesc;
        Inventory._name.text = newMisc.ItemName;
        Inventory._image = newMisc.Icon;
    }
}
