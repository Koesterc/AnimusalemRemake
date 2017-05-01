using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class Item : ScriptableObject
{
    public Sprite icon;
    public int itemID;
    public string[] HGNames = { "Glock", "beretta", "P10" };
    public string itemDesc = "The glock may not be the most powerful chocie for a handgun; however, it's superiority comes from its rate of fire and clip size.";
    public int levelRestriction;
    float weight;

    //enhancements
    public int enhancedDamage;
    public float enhancedFireRate;
    public float enhancedReload;
    public int enhancedCapacity;
    public int enhancedAccuracy;
    public int enhancedCriticalChance;
    public int enhancedCriticalHit;
    //exclusives
    public int poisonDamage;
    public int lightDamage;
    public int fireDamage;
    public int coldDamage;
    public int ignoreArmor;
    public int coldRes;
    public int fireRes;
    public int lightRes;
    public int poisonRes;
    public float stun;
    public int leech; //leeches enemyhealth (heals the palyer's health based on the amount of damage done
    public float regen; //the rate at which a player regenerates health
    public float aimAssist; //makes the crossair travel slower when it touches the enemy
    public int additionalXP;
    public int additionalGold;
    //Bonuses/ Perks
    public int luck;
    public int strength;
    public int charisma;
    public int agility;
    public int perception;
    public int constitution;
    public int dexterity;
    public int intelligence;
    public int fortitude;

    public enum ItemType { weapon, ring, belt, boots, gloves, amulate, key, aid, quest };


    public ItemType itemType
    {
        get { return itemType; }
        set { itemType = value; }
    }
}
