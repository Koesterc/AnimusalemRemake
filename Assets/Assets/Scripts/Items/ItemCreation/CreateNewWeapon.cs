﻿using System.Collections;
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
            newWeapon.Leech += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.AdditionalXP = Mathf.Round(Random.Range(.25f, .5f) * 100) / 100;
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newWeapon.AdditionalGold = Mathf.Round(Random.Range(.25f, .5f) * 100) / 100;

        ChooseWeaponType();
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

                //adding bonuses
                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(1, 8);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Random.Range(.03f, .05f);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);

                //weapon stats
                newWeapon.Damage = Random.Range(8+newWeapon.LevelRestriction+newWeapon.EnhancedDamage, 15+newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Capacity = Random.Range(8 + newWeapon.ExtendedClip, 15 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                break;
            case 1:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Rifle;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(1, 3);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(5, 15);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.05f, .15f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Damage = Random.Range(8 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 15 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(3 + newWeapon.ExtendedClip, 5 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) *100)/100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.10f + newWeapon.IncreasedCriticalChance, .18f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(1.0f, 2.5f) * 100) / 100;
                break;
            case 2:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Shotgun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.CapacityLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(1, 2);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(10, 20);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Damage = Random.Range(30 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 50 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(2 + newWeapon.ExtendedClip, 4 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(2f, 4f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                break;
            case 3:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Machinegun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.FireRateLvl = 5;


                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(10, 20);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 3);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.08f, .12f) * 10) / 10;
                newWeapon.Damage = Random.Range(5 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 8 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(30 + newWeapon.ExtendedClip, 50 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                break;
            case 4:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.AssaultRifle;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.FireRateLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(5 + newWeapon.LevelRestriction, 12 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(5, 15);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(5, 15);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.14f, .18f) * 100) / 10;
                newWeapon.Damage = Random.Range(12 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 16 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(20 + newWeapon.ExtendedClip, 35 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                break;
            case 5:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Magnum;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                newWeapon.CapacityLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.ExtendedClip += Random.Range(1, 3);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(20, 30);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 10);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(1.2f, 1.6f) * 10) / 10;
                newWeapon.Damage = Random.Range(40 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 80 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(8 + newWeapon.ExtendedClip, 15 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                break;
            case 6:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Explosive;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.EnhancedDamage += Random.Range(30 + newWeapon.LevelRestriction, 50 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.PoisonDamage = Random.Range(20, 40);
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newWeapon.IgnoreArmor = Random.Range(1, 10);

                //weapon stats
                newWeapon.Damage = Random.Range(100 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 15 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Firerate = newWeapon.Reload;
                newWeapon.Capacity = 1;
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
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
