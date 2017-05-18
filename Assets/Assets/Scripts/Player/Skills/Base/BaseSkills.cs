using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkills
{
    int energyCost;
    float spellDuration;
    float coolDown;
    int requiredLevel;
    int curLevel;
    string name;

    public enum AbilityTypes
    {
        Passive,
        Active
    }
    public enum SkillTypes
    {
        Offensive, //offensive, combat
        Defensive, //defensive, protection
        Medical, //restoration spells, healing items, etc
        Chemistry, //crafting items
        Technical,//locksmith, computers, technology, repairs, etc
        Pursuasive //barter, luck, speech
    }

    private AbilityTypes abilityTypes;

    public AbilityTypes AbilityType
    {
        get { return abilityTypes; }
        set { abilityTypes = value; }
    }

    public int EnergyCost
    {
        get { return energyCost; }
        set { energyCost = value;}
    }
    public float SpellDuration
    {
        get { return spellDuration; }
        set { spellDuration = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
    }
    public int RequiredLevel
    {
        get { return requiredLevel; }
        set { requiredLevel = value; }
    }
    public int CurLevel
    {
        get { return curLevel; }
        set { curLevel = value; }
    }
}
