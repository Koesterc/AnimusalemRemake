using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour {
    private BaseWeapon newWeapon;
    private string[] myName = //handgun 0-7
    { "Custom HG40", "SDK5","9mm Oppressor", "Anacanda", "Blacklist", "Punisher", "SNAL-141", "Trident",
     //shotguns 8-14
    "12 Gauge","Cerberus","Orthrus","Grave Digger","Devestater","BlunderBuss","Ravager",
     //rifles 15-24
     "P4 Suppressor","PK1","Predator","Raven","Eagle's Eye","Hunter Killer","Crow's Nest","Hawk", "Hecaerge","Oupis",
     //machineguns 25-34
     "RP8","Rapidfire lC20","MDK 4","SMG 120","Carbon P40","Diminisher","HR2 Stingray", "Scorpion", "Hailstorm","Hydra",
     //assault Rifles 35-41
     "Cobra VP","MK4 Firestorm","M14 Viper","AR-17","G7 Battle Rifle","Warhammer","M1-41 Chineese Assault Rifle",
     //magnums 42-45
     "Reaper","Day Ender","Banshee","Zeus",
     //explosives 46-53
     "Kamikaze","PK Destroyer","Iradicator","Goliath","Warhammer","Horizon's Nuke", "Bazooka", "Winter's Plow"};

    public void CreateWeapon()
    {

        newWeapon = new BaseWeapon();
        newWeapon.ItemID = Random.Range(0, 10000);
        int temp = Random.Range(0, 100);
        if (temp >= 95)//use luck here to increase the chance of magic item
            newWeapon.Leech += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 95)
            newWeapon.AdditionalXP = Mathf.Round(Random.Range(.25f, .5f) * 100) / 100;
        temp = Random.Range(0, 100);
        if (temp >= 95)
            newWeapon.AdditionalGold = Mathf.Round(Random.Range(.25f, .5f) * 100) / 100;
        temp = Random.Range(0, 100);
        if (temp >= 95)
            newWeapon.ReducedWeight = Mathf.Round(Random.Range(.1f, .5f) * 100) / 100;
        newWeapon.LevelRestriction = Random.Range(PlayerStats.curLevel-5, PlayerStats.curLevel + 5);
        if (newWeapon.LevelRestriction < 1)
            newWeapon.LevelRestriction = 1;

        ChooseWeaponType();
        newWeapon.SellValue += ((int)(newWeapon.AdditionalGold * 8) + ((int)newWeapon.AdditionalXP * 8) +
            newWeapon.Leech * 2 + (int)(newWeapon.ReducedWeight*10));
        newWeapon.Weight = newWeapon.Weight - (newWeapon.Weight*newWeapon.ReducedWeight);

        newWeapon.CostValue = newWeapon.SellValue * 10;

        //the power of all upgrades
        newWeapon.UpDamage = (int)(newWeapon.Damage*.1);
        newWeapon.UpFireRate = (newWeapon.Firerate*.05f);
        newWeapon.UpReload = (newWeapon.ExpeditiveReload * .1f);
        newWeapon.UpCriticalChance = (newWeapon.CriticalChance * .8f); 
        newWeapon.UpCriticalDamage = (newWeapon.CriticalDamage * .3f);
        newWeapon.UpCapacity = (int)(newWeapon.Capacity* .2f);
        newWeapon.UpAccuracy = (newWeapon.Accuracy * .05f);
    }

    public void ChooseWeaponType()
    {
        int temp = Random.Range(0, 7);

        switch (temp)
        {
            default:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Handgun;
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(0, 7)];

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(1, 8);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(1+newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.3f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 90 || newWeapon.ItemName == "Trident")
                    newWeapon.ThreeRoundBurst = true;

                newWeapon.Weight = Random.Range(3, 5);

                //weapon stats
                newWeapon.Damage = Random.Range(8+newWeapon.LevelRestriction+newWeapon.EnhancedDamage, 15+newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Capacity = Random.Range(8 + newWeapon.ExtendedClip, 15 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 2 + (int)(newWeapon.Capacity/8) + newWeapon.PoisonDamage +
                    (int)(newWeapon.Damage/4) + (int)(6 - newWeapon.Reload)+(int)(4 - (newWeapon.Firerate * 3)) + 
                    (int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 5)+
                    (int)(newWeapon.Accuracy * 3));
                newWeapon.ItemDesc = "The "+newWeapon.ItemName+" is sidearm with a " + newWeapon.Capacity + " round magazine. It uses traditional handgun bullets.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Handguns/Handgun");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Handgun");
                break;
            case 1:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Rifle;
                temp = Random.Range(0, 2);
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(15, 24)];

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(1, 3);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.05f, .15f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ThreeRoundBurst = true;
                newWeapon.Weight = Random.Range(4, 7);

                newWeapon.RequiredDexterity = Random.Range(0, 6 * newWeapon.LevelRestriction);
                newWeapon.RequiredIntelligence = Random.Range(0, 4 * newWeapon.LevelRestriction);
                newWeapon.RequiredStrength = Random.Range(0, 2 * newWeapon.LevelRestriction);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Damage = Random.Range(8 + (newWeapon.LevelRestriction * 2) + newWeapon.EnhancedDamage, 15 + (newWeapon.LevelRestriction * 2) + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(3 + newWeapon.ExtendedClip, 5 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) *100)/100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.10f + newWeapon.IncreasedCriticalChance, .18f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(1.0f, 2.5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 2 + (int)(newWeapon.Capacity/8)+ (int)(newWeapon.PoisonDamage/2) +
                (int)(newWeapon.Damage/4) + (int)(6 - newWeapon.Reload) + (int)(4 - (newWeapon.Firerate * 3)) +
                (int)(newWeapon.CriticalChance * 10) + (int)(newWeapon.CriticalDamage * 2) +
                (int)(newWeapon.Accuracy * 3));
                newWeapon.ItemDesc = "The "+newWeapon.ItemName+" is a long sturdy rifle. Rifles have a far greater chance to perform critical hits and deal greater damage than other firearms when achieved.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Rifles/Rifle");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Rifle");
                break;
            case 2:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Shotgun;
                temp = Random.Range(0, 2);
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(8, 14)];
                newWeapon.CapacityLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(1, 2);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(10 + newWeapon.LevelRestriction, 20 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 90 && !newWeapon.ThreeRoundBurst && !newWeapon.TrippleBarrel)
                {
                    newWeapon.TrippleBarrel = false;
                    newWeapon.ThreeRoundBurst = false;
                    newWeapon.DoubleBarrel = true;
                }
                temp = Random.Range(0, 100);
                if (temp >= 90 && !newWeapon.ThreeRoundBurst && !newWeapon.DoubleBarrel)
                {
                    newWeapon.ThreeRoundBurst = false;
                    newWeapon.DoubleBarrel = false;
                    newWeapon.TrippleBarrel = true;
                }
                newWeapon.Weight = Random.Range(7, 10);

                newWeapon.RequiredDexterity = Random.Range(0, 2 * newWeapon.LevelRestriction);
                newWeapon.RequiredStrength = Random.Range(0, 6 * newWeapon.LevelRestriction);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.8f, 1.2f) * 10) / 10;
                newWeapon.Damage = Random.Range(30 + (newWeapon.LevelRestriction * 2) + newWeapon.EnhancedDamage, 50 + (newWeapon.LevelRestriction * 2) + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(2 + newWeapon.ExtendedClip, 4 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(2f, 4f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 2 + newWeapon.Capacity * 2 + newWeapon.PoisonDamage +
      (int)(newWeapon.Damage/15) + (int)(6 - newWeapon.Reload) + (int)(8 - (newWeapon.Firerate * 3)) +
      (int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 5) +
      (int)(newWeapon.Accuracy/2));
                newWeapon.ItemDesc = "The "+newWeapon.ItemName+" shotgun has a wide range of attack allowing the user to strike multiple targets that are grouped.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Shotguns/Shotgun");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Shotgun");
                break;
            case 3:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Machinegun;
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(25, 34)];
                newWeapon.FireRateLvl = 5;


                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(10, 20);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(1 + newWeapon.LevelRestriction, 5 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 3);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ThreeRoundBurst = true;
                newWeapon.Weight = Random.Range(3, 5);


                newWeapon.RequiredDexterity = Random.Range(0, 6 * newWeapon.LevelRestriction);
                newWeapon.RequiredIntelligence = Random.Range(0, 2 * newWeapon.LevelRestriction);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.08f, .12f) * 10) / 10;
                newWeapon.Damage = Random.Range(5 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 8 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(30 + newWeapon.ExtendedClip, 60 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 3 + (int)(newWeapon.Capacity/10) + newWeapon.PoisonDamage +
      (int)(newWeapon.Damage/4) + (int)(8 - newWeapon.Reload) + (int)(8 - (newWeapon.Firerate * 20)) +
      (int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 3) +
      (int)(newWeapon.Accuracy * 3));
                newWeapon.ItemDesc = "The sub machineguns, such as the "+newWeapon.ItemName+", are extremely light and and easy to handle thus they are superior to all other weapons when it comes down to capacity, fire rate, and reload.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Machineguns/Machinegun");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Machinegun");
                break;
            case 4:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.AssaultRifle;
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(35, 41)];
                newWeapon.FireRateLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(5 + newWeapon.LevelRestriction, 12 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(5, 15);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(5 + newWeapon.LevelRestriction, 15 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 5);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ThreeRoundBurst = true;
                newWeapon.Weight = Random.Range(7, 10);

                newWeapon.RequiredDexterity = Random.Range(0, 3 * newWeapon.LevelRestriction);
                newWeapon.RequiredIntelligence = Random.Range(0, 2 * newWeapon.LevelRestriction);
                newWeapon.RequiredStrength = Random.Range(0, 4 * newWeapon.LevelRestriction);


                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(.14f, .18f) * 100) / 10;
                newWeapon.Damage = Random.Range(12 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage, 16 + newWeapon.LevelRestriction + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(20 + newWeapon.ExtendedClip, 35 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 3 + (int)(newWeapon.Capacity/8)+ newWeapon.PoisonDamage +
      (int)(newWeapon.Damage/6) + (int)(8 - newWeapon.Reload) + (int)(8 - (newWeapon.Firerate * 3)) +
      (int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 3) +
      (int)(newWeapon.Accuracy * 3));
                newWeapon.ItemDesc = "The assault rifles pack a much heavier punch than the SMGs, but they are less accurate and not nearly as fast.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/AssaultRifles/AssaultRifle");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/AssaultRifle");
                break;
            case 5:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Magnum;
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(42, 45)];
                newWeapon.CapacityLvl = 5;

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ExtendedClip += Random.Range(1, 3);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(20 + newWeapon.LevelRestriction, 30 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 10);
                newWeapon.Weight = Random.Range(4, 7);

                newWeapon.RequiredDexterity = Random.Range(0, 4 * newWeapon.LevelRestriction);
                newWeapon.RequiredIntelligence = Random.Range(0, 3 * newWeapon.LevelRestriction);
                newWeapon.RequiredStrength = Random.Range(0, 5 * newWeapon.LevelRestriction);

                //weapon stats
                newWeapon.Firerate = Mathf.Round(Random.Range(1.2f, 1.6f) * 10) / 10;
                newWeapon.Damage = Random.Range(40 + (newWeapon.LevelRestriction * 5) + newWeapon.EnhancedDamage, 80 + (newWeapon.LevelRestriction * 5) + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Capacity = Random.Range(8 + newWeapon.ExtendedClip, 15 + newWeapon.ExtendedClip);
                newWeapon.Accuracy = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor * 3 + (int)(newWeapon.Capacity / 8) + newWeapon.PoisonDamage +
(int)(newWeapon.Damage / 20) + (int)(8 - newWeapon.Reload) + (int)(3 - (newWeapon.Firerate)) +
(int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 3) +
(int)(newWeapon.Accuracy * 10));
                newWeapon.ItemDesc = "Although very powerful, the "+newWeapon.ItemName+" is not so easily handled. Its firerate is far less than your typical handgun and the kickback makes it far more challenging to hit targets.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Magnums/Magnum");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Magnum");
                break;
            case 6:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Explosive;
                temp = Random.Range(0, 2);
                //assigning the name
                newWeapon.ItemName = myName[Random.Range(46, 53)];

                //adding bonuses
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.EnhancedDamage += Random.Range(30 + newWeapon.LevelRestriction, 50 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.PoisonDamage = Random.Range(20 + newWeapon.LevelRestriction, 40 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.ColdDamage = Random.Range(20 + newWeapon.LevelRestriction, 40 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.FireDamage = Random.Range(20 + newWeapon.LevelRestriction, 40 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.LightDamage = Random.Range(20 + newWeapon.LevelRestriction, 40 + newWeapon.LevelRestriction);
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IncreasedCriticalChance = Mathf.Round(Random.Range(.03f, .05f) * 100) / 100;
                temp = Random.Range(0, 100);
                if (temp >= 95)
                    newWeapon.IgnoreArmor = Random.Range(1, 10);
                newWeapon.Weight = Random.Range(15, 20);

                newWeapon.RequiredDexterity = Random.Range(0, 6 * newWeapon.LevelRestriction);
                newWeapon.RequiredIntelligence = Random.Range(0, 3 * newWeapon.LevelRestriction);
                newWeapon.RequiredStrength = Random.Range(0, 8 * newWeapon.LevelRestriction);

                //weapon stats
                newWeapon.Damage = Random.Range(40 + (newWeapon.LevelRestriction * 8) + newWeapon.EnhancedDamage, 150 + (newWeapon.LevelRestriction * 8) + newWeapon.EnhancedDamage);
                newWeapon.Reload = Mathf.Round(Random.Range(3f, 5f) * 10) / 10;
                newWeapon.Firerate = newWeapon.Reload;
                newWeapon.Capacity = 1;
                newWeapon.Accuracy = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;
                newWeapon.CriticalChance = Mathf.Round(Random.Range(.03f + newWeapon.IncreasedCriticalChance, .05f + newWeapon.IncreasedCriticalChance) * 100) / 100;
                newWeapon.CriticalDamage = Mathf.Round(Random.Range(.3f, .5f) * 100) / 100;

                newWeapon.SellValue = (newWeapon.IgnoreArmor + (int)(newWeapon.PoisonDamage/10) +
(int)(newWeapon.Damage / 50) + (int)(8 - newWeapon.Reload) + (int)(3 - (newWeapon.Firerate)) +
(int)(newWeapon.CriticalChance * 50) + (int)(newWeapon.CriticalDamage * 3) +
(int)(newWeapon.Accuracy * 10));
                newWeapon.ItemDesc = "The "+newWeapon.ItemName+" is a powerful, single round explosive. Although it is the most powerful type of weapon available, ammo for it is by far the most scarce.";
                newWeapon.Icon = Resources.Load<Sprite>("Icons/Weapons/Explosives/Explosive");
                newWeapon.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Explosive");
                break;
        }
    }
    public BaseWeapon NewWeapon
    {
        get { return newWeapon; }
        set { newWeapon = value; }
    }
}
