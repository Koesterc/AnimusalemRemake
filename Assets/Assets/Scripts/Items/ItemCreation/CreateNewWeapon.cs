using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewWeapon : MonoBehaviour {
    private BaseWeapon newWeapon;
    public GameObject droppedWeapon;
    private string[] handgun = { "Grave Digger", "Day Ender", "The BlackList" };

    void Start()
    {
        CreateWeapon();
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = newWeapon.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = newWeapon.ItemName;

        //print(newWeapon.ItemDesc);
        //print(newWeapon.ItemName);
        //print(newWeapon.Constitution);
        //print(newWeapon.Strength);
        //print(newWeapon.Intelligence);
        //print(newWeapon.Dexterity);
        //print(newWeapon.Fortitude);
        //print(newWeapon.Agility);
        //print(newWeapon.Perception);
        //print(newWeapon.Charisma);
        //print(newWeapon.Luck);
    }

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();
        newWeapon.ItemDesc = "It's a gun...";
        newWeapon.ItemID = Random.Range(0, 10000);
        int temp = Random.Range(0, 100);
        if (temp >= 90)//use luck here to increase the chance of magic item
        newWeapon.Constitution += Random.Range(1, 5);
 
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Strength += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Intelligence += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Dexterity += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Fortitude += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Agility += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Perception += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Charisma += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.Luck += Random.Range(1, 5);
 


        ChooseWeaponType();

        //setting the damage, and other weapon stats

        //determine whether the weapon is good or not and set the level restrictions to it
        //  newWeapon.LevelRestriction = Random.Range(curLevel -5, curLevel+5);
        //  newWeapon.RequiredStrength = Random.Range(newWeapon.LevelRestriction * 2, newWeapon.LevelRestriction * 3);
        //  newWeapon.RequiredDexterity = Random.Range(newWeapon.LevelRestriction * 2, newWeapon.LevelRestriction * 3);
    }

    private void ChooseWeaponType()
    {
        int temp = Random.Range(0, 7);

        switch (temp)
        {
            default:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Handgun;
                //assigning the name
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 1:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Rifle;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 2:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Shotgun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.CapacityLvl = 5;
                break;
            case 3:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Machinegun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.FireRateLvl = 5;
                break;
            case 4:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.AssaultRifle;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.FireRateLvl = 3;
                break;
            case 5:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Magnum;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.CapacityLvl = 5;
                break;
            case 6:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Explosive;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
        }
    }

    public void DroppedWeapon()
    {
        GameObject clone;
        clone = Instantiate(droppedWeapon, Controls._Player.transform.position, transform.rotation) as GameObject;
        clone.AddComponent<DroppedWeapon>().DropWeapon(newWeapon);
        Destroy(gameObject);
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = newWeapon.ItemDesc;
        Inventory._name.text = newWeapon.ItemName;
        Inventory._image = newWeapon.Icon;

        Inventory.rlBar.transform.localScale = new Vector3(newWeapon.ReloadLvl/5,1,1);
        Inventory.frBar.transform.localScale = new Vector3(newWeapon.ReloadLvl / 5, 1, 1);
        Inventory.dmgBar.transform.localScale = new Vector3(newWeapon.FireRateLvl / 5,1,1);
        Inventory.ccBar.transform.localScale = new Vector3(newWeapon.DamageLvl / 5, 1, 1);
        Inventory.cdBar.transform.localScale = new Vector3(newWeapon.CapacityLvl / 5, 1, 1);
        Inventory.accBar.transform.localScale = new Vector3(newWeapon.CriticalChanceLvl / 5, 1, 1);
        Inventory.capBar.transform.localScale = new Vector3(newWeapon.CriticalDamageLvl / 5,1,1);
    }
}
