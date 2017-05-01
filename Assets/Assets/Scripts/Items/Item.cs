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
    int enhancedDamage;
    float enhancedFireRate;
    float enhancedReload;
    int enhancedCapacity;
    int enhancedAccuracy;
    int enhancedCriticalChance;
    int enhancedCriticalHit;
    //exclusives
    int poisonDamage;
    int lightDamage;
    int fireDamage;
    int coldDamage;
    int ignoreArmor;
    int coldRes;
    int fireRes;
    int lightRes;
    int poisonRes;
    float stun;
    int leech; //leeches enemyhealth (heals the palyer's health based on the amount of damage done
    float regen; //the rate at which a player regenerates health
    float aimAssist; //makes the crossair travel slower when it touches the enemy
    int additionalXP;
    int additionalGold;
    //Bonuses/ Perks
    int luck;
    int strength;
    int charisma;
    int agility;
    int perception;
    int constitution;
    int dexterity;
    int intelligence;
    int fortitude;

    public enum ItemType { weapon, ring, belt, boots, gloves, amulate, key, aid, quest };


    public ItemType itemType
    {
        get { return itemType; }
        set { itemType = value; }
    }
}
