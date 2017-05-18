using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCombat : BaseSkills
{
    int damage;
    int defense;
    int restore;
    float enhancement;


    public int Damage
    {
        get { return damage; }
        set { restore = value; }
    }
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    public int Restore
    {
        get { return restore; }
        set { restore = value; }
    }
}
