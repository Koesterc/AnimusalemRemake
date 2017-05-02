using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatItem : BaseItem
{
    int constitution;
    int strength;
    int dexterity;
    int intelligence;
    int fortitude;
    int luck;
    int charisma;
    int perception;
    int agility;

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
}


