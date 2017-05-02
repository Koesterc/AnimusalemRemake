using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class BaseItem : ScriptableObject
{
    Sprite icon;
    int itemID;
    string itemName;
   // public string[] HGNames = { "Glock", "beretta", "P10" };
    string itemDesc = "The glock may not be the most powerful chocie for a handgun; however, it's superiority comes from its rate of fire and clip size.";
    int levelRestriction;
    //player requirements
    int requiredStrength;
    int requiredDexterity;
    int requiredIntelligence;
    float weight;
    int sellValue;
    public enum ItemTypes { weapon, armor, ring, belt, boots, gloves, amulate, misc};
    private ItemTypes itemTypes;


    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string ItemDesc
    {
        get { return itemDesc; }
        set { itemDesc = value; }
    }
    public int LevelRestriction
    {
        get { return levelRestriction; }
        set { levelRestriction = value; }
    }
    public int RequiredStrength
    {
        get { return requiredStrength; }
        set { requiredStrength = value; }
    }
    public int RequiredDexterity
    {
        get { return requiredDexterity; }
        set { requiredDexterity = value; }
    }
    public int RequiredIntelligence
    {
        get { return requiredIntelligence; }
        set { requiredIntelligence = value; }
    }
    public float Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    public ItemTypes ItemType
    {
        get { return itemTypes; }
        set { itemTypes = value; }
    }
    public int SellValue
    {
        get { return sellValue; }
        set { sellValue = value; }
    }
    ////enhancements
    //public int enhancedDamage;
    //public float enhancedFireRate;
    //public float enhancedReload;
    //public int enhancedCapacity;
    //public int enhancedAccuracy;
    //public int enhancedCriticalChance;
    //public int enhancedCriticalHit;
    ////exclusives
    //public int poisonDamage;
    //public int lightDamage;
    //public int fireDamage;
    //public int coldDamage;
    //public int ignoreArmor;
    //public int coldRes;
    //public int fireRes;
    //public int lightRes;
    //public int poisonRes;
    //public float stun;
    //public int leech; //leeches enemyhealth (heals the palyer's health based on the amount of damage done
    //public float regen; //the rate at which a player regenerates health
    //public float aimAssist; //makes the crossair travel slower when it touches the enemy
    //public int additionalXP;
    //public int additionalGold;
    ////Bonuses/ Perks
    //public int luck;
    //public int strength;
    //public int charisma;
    //public int agility;
    //public int perception;
    //public int constitution;
    //public int dexterity;
    //public int intelligence;
    //public int fortitude;


}
