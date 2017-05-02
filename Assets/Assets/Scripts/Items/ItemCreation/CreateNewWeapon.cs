using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWeapon : MonoBehaviour {
    private BaseWeapon newWeapon;
    private string[] handgun = { "Grave Digger", "Weapon Of The Damned", "The BlackList" };

    void Start()
    {
        CreateWeapon();
        print(newWeapon.ItemDesc);
        print(newWeapon.ItemName);
        print(newWeapon.Constitution);
    }

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();
        int temp = Random.Range(0, handgun.Length);
        newWeapon.ItemDesc = "This is a very powerful weapon";
        newWeapon.ItemID = Random.Range(0, 10000);
        newWeapon.Constitution += Random.Range(0, 5);
        newWeapon.Strength += Random.Range(0, 5);
        newWeapon.Intelligence += Random.Range(0, 5);
        newWeapon.Dexterity += Random.Range(0, 5);
        newWeapon.Fortitude += Random.Range(0, 5);
        newWeapon.Agility += Random.Range(0, 5);
        newWeapon.Perception += Random.Range(0, 5);
        ChooseWeaponType();

        //setting the damage, and other weapon stats
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
                break;
            case 2:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Shotgun;
                break;
            case 3:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Machinegun;
                break;
            case 4:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.AssaultRifle;
                break;
            case 5:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Magnum;
                break;
            case 6:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Explosive;
                break;
        }
    }



}
