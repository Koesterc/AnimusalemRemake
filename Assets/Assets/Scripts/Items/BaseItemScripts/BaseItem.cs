using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
[System.Serializable]
public class BaseItem
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

    int constitution;
    int strength;
    int dexterity;
    int intelligence;
    int fortitude;
    int luck;
    int charisma;
    int perception;
    int agility;
    float reducedWeight;

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public float ReducedWeight
    {
        get { return reducedWeight; }
        set { reducedWeight = value; }
    }

    public int Constitution
    {
        get { return constitution; }
        set { constitution = value; }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }
    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
    public int Fortitude
    {
        get { return fortitude; }
        set { fortitude = value; }
    }
    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }
    public int Charisma
    {
        get { return charisma; }
        set { charisma = value; }
    }
    public int Perception
    {
        get { return perception; }
        set { perception = value; }
    }
    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }


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
}
