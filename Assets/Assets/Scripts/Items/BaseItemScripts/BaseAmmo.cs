using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAmmo: BaseItem
{

    public enum AmmoType
    {
        HandgunAmmo,
        ShotgunShells,
        RifleAmmo,
        MachinegunAmmo,
        AssaultRifleAmmo,
        MagnumAmmo,
        ExplosiveRounds
    }

    private AmmoType ammoTypes;

    public AmmoType AmmoTypes
    {
        get { return ammoTypes; }
        set { ammoTypes = value; }
    }

    int quantity;

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}
