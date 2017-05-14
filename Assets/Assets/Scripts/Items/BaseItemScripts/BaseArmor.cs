using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseArmor : BaseItem
{
    public enum ArmorType
    {
        Heavy,
        Medium,
        Light
    }
    private ArmorType armorTypes;

    private int speedReduction;
    private int fireRes;
    private int lightRes;
    private int coldRes;
    private int poisonRes;
    private int defense;
    private int enhancedDefense;
    private float maxHealth;

    public ArmorType ArmorTypes
    {
        get { return armorTypes; }
        set { armorTypes = value; }
    }
    public int EnhancedDefense
    {
        get { return enhancedDefense; }
        set { enhancedDefense = value; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int ColdRes
    {
        get { return coldRes; }
        set { coldRes = value; }
    }
    public int FireRes
    {
        get { return fireRes; }
        set { fireRes = value; }
    }
    public int PoisonRes
    {
        get { return poisonRes; }
        set { poisonRes = value; }
    }
    public int LightRes
    {
        get { return lightRes; }
        set { lightRes = value; }
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
