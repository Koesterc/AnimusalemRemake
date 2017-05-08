using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseMisc : BaseItem {

    public enum MiscType
    {
        SmallAid,
        MediumAid,
        LargeAid,
        PainKiller,
        HolyWater,
        DreamCatcher,
        HandgunAmmo,
        ShotgunShells,
        RifleAmmo,
        MachinegunAmmo,
        AssaultRifleAmmo,
        MagnumAmmo,
        ExplosiveRounds,
        OldKey
    }
    int quantity;

    public int Quanntity
    {
        get { return quantity; }
        set { quantity = value; }
    }


    private MiscType miscTypes;

    public MiscType MiscTypes
    {
        get { return miscTypes; }
        set { miscTypes = value; }
    }

}
