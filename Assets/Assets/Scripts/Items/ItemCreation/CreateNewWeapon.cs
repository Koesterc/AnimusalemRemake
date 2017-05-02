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
        print(newWeapon.Strength);
        print(newWeapon.Intelligence);
        print(newWeapon.Dexterity);
        print(newWeapon.Agility);
        print(newWeapon.Luck);
        print(newWeapon.Charisma);
    }

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();
        newWeapon.ItemDesc = "This is a very powerful weapon";
        newWeapon.ItemID = Random.Range(0, 10000);
        int temp = Random.Range(0, 10);
        if (temp >= 10)//use luck here to increae the chance of magic item
        newWeapon.Constitution += Random.Range(1, 5);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Strength += Random.Range(1, 5);
        Debug.Log("temp:" +temp);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Intelligence += Random.Range(1, 5);
        Debug.Log("temp:" +temp);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Dexterity += Random.Range(1, 5);
        Debug.Log("temp:" +temp);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Fortitude += Random.Range(1, 5);
        Debug.Log("temp:" + temp);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Agility += Random.Range(1, 5);
        Debug.Log("temp:" + temp);
        temp = Random.Range(0, 12);
        if (temp >= 10)
            newWeapon.Perception += Random.Range(1, 5);
        Debug.Log("temp:" + temp);


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
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 2:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Shotgun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 3:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Machinegun;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 4:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.AssaultRifle;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 5:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Magnum;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
            case 6:
                newWeapon.WeaponTypes = BaseWeapon.WeaponType.Explosive;
                temp = Random.Range(0, 2);
                newWeapon.ItemName = handgun[temp];
                break;
        }
    }



}
