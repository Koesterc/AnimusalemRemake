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
        switch (temp)
        {
            default:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.HandgunAmmo;
                //assigning the name
                newAmmo.ItemName = "Handgun Bullets";
                newAmmo.ItemDesc = "9mm handgun bullets.";
                newAmmo.Quantity = Random.Range(5, 10);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.hgAmmoWeight;
                break;
            case 1:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.ShotgunShells;
                //assigning the name
                newAmmo.ItemName = "Shotgun Shells";
                newAmmo.ItemDesc = "12 gauge shells.";
                newAmmo.Quantity = Random.Range(1, 3);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.sgAmmoWeight;
                break;
            case 2:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.RifleAmmo;
                //assigning the name
                newAmmo.ItemName = "Rifle Rounds";
                newAmmo.ItemDesc = "30 caliber rounds.";
                newAmmo.Quantity = Random.Range(1, 3);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.rifleAmmoWeight;
                break;
            case 3:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.MachinegunAmmo;
                //assigning the name
                newAmmo.ItemName = "Machinegun Bullets";
                newAmmo.ItemDesc = ".40 carbine bullets.";
                newAmmo.Quantity = Random.Range(10, 20);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.mgAmmoWeight;
                break;
            case 4:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.AssaultRifleAmmo;
                //assigning the name
                newAmmo.ItemName = "Assault Rifle Ammunition";
                newAmmo.ItemDesc = "5.56 NATO rounds.";
                newAmmo.Quantity = Random.Range(5, 15);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.arAmmoWeight;
                break;
            case 5:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.MagnumAmmo;
                //assigning the name
                newAmmo.ItemName = "Magnum Rounds";
                newAmmo.ItemDesc = ".357 magnum rounds.";
                newAmmo.Quantity = Random.Range(1, 2);
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.magnumAmmoWeight;
                break;
            case 6:
                newAmmo.AmmoTypes = BaseAmmo.AmmoType.ExplosiveRounds;
                //assigning the name
                newAmmo.ItemName = "Explosive Rounds";
                newAmmo.ItemDesc = "These can be used the heavier artilery.";
                newAmmo.Quantity = 1;
                newAmmo.Weight = newAmmo.Quantity * PlayerStats.explosiveAmmoWeight;
                break;
        }
    }

    public BaseAmmo NewAmmo
    {
        get { return newAmmo; }
        set { newAmmo = value; }
    }
}