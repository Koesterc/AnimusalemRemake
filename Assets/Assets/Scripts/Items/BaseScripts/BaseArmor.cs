using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArmor : BaseStatItem
{
    public enum ArmorType
    {
        Heavy,
        Medium,
        Light
    }
    private ArmorType armorTypes;

    public int speedReduction;
    public int defense;

    public ArmorType ArmorTypes
    {
        get { return armorTypes; }
        set { armorTypes = value; }
    }
    public int SpeedReduction
    {
        get { return speedReduction; }
        set { speedReduction = value; }
    }
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

}
