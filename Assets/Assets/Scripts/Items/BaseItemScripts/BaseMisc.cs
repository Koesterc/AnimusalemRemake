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
        OldKey
    }
    private MiscType miscTypes;

    public MiscType MiscTypes
    {
        get { return miscTypes; }
        set { miscTypes = value; }
    }

}
