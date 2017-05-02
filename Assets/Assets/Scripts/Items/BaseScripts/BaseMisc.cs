using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMisc : BaseItem {

    public enum MiscType
    {
        SmallAid,
        MediumAid,
        LargeAid,
        OldKey
    }
    private MiscType miscTypes;

    public MiscType miscType
    {
        get { return miscTypes; }
        set { miscTypes = value; }
    }

}
