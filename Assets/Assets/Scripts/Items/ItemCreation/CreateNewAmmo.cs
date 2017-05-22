using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewAmmo : MonoBehaviour
{
    private BaseAmmo newAmmo;
    void Start()
    {
    }
    public void CreateAmmo()
    {
        newAmmo = new BaseAmmo();
        newAmmo.ItemID = Random.Range(0, 10000);
        int temp = Random.Range(0, 7);
        newAmmo.MapIcon = Resources.Load<Sprite>("Icons/MapIcons/Ammo");
        switch (temp)
        {
            default:
                newAmmo.SellValue = 2;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.HandgunAmmo;
                //assigning the name
                newAmmo.ItemName = "Handgun Bullets";
                newAmmo.ItemDesc = "9mm handgun bullets.";
                newAmmo.Quantity = Random.Range(5, 10);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.hgAmmoWeight;
                newAmmo.Icon= Resources.Load<Sprite>("Icons/Ammo/Handgun");
                break;
            case 1:
                newAmmo.SellValue = 5;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.ShotgunShells;
                //assigning the name
                newAmmo.ItemName = "Shotgun Shells";
                newAmmo.ItemDesc = "12 gauge shells.";
                newAmmo.Quantity = Random.Range(1, 3);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.sgAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/Shotgun");
                break;
            case 2:
                newAmmo.SellValue = 4;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.RifleAmmo;
                //assigning the name
                newAmmo.ItemName = "Rifle Rounds";
                newAmmo.ItemDesc = "30 caliber rounds.";
                newAmmo.Quantity = Random.Range(1, 3);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.rifleAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/Rifle");
                break;
            case 3:
                newAmmo.SellValue = 1;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.MachinegunAmmo;
                //assigning the name
                newAmmo.ItemName = "Machinegun Bullets";
                newAmmo.ItemDesc = ".40 carbine bullets.";
                newAmmo.Quantity = Random.Range(10, 20);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.mgAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/Machinegun");
                break;
            case 4:
                newAmmo.SellValue = 2;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.AssaultRifleAmmo;
                //assigning the name
                newAmmo.ItemName = "Assault Rifle Bullets";
                newAmmo.ItemDesc = "5.56 NATO rounds.";
                newAmmo.Quantity = Random.Range(5, 15);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.arAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/AssaultRifle");
                break;
            case 5:
                newAmmo.SellValue = 8;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.MagnumAmmo;
                //assigning the name
                newAmmo.ItemName = "Magnum Rounds";
                newAmmo.ItemDesc = ".357 magnum rounds.";
                newAmmo.Quantity = Random.Range(1, 2);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.magnumAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/Magnum");
                break;
            case 6:
                newAmmo.SellValue = 12;
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.ExplosiveRounds;
                //assigning the name
                newAmmo.ItemName = "Explosive Rounds";
                newAmmo.ItemDesc = "These can be used with the heavier artilery.";
                newAmmo.Quantity = 1;
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.explosiveAmmoWeight;
                newAmmo.Icon = Resources.Load<Sprite>("Icons/Ammo/Explosive");
                break;
        }
    }

    public BaseAmmo NewAmmo
    {
        get { return newAmmo; }
        set { newAmmo = value; }
    }
}