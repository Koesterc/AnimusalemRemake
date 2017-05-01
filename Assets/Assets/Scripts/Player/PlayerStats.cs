using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    //player Info
    [Header("Items")]
    public int money;
    [Tooltip("Handgun Ammo")]
    public int hgAmmo;
    [Tooltip("Shotgun Ammo")]
    public int sgAmmo;
    [Tooltip("MachineGun Ammo")]
    public int mgAmmo;
    [Tooltip("Assault Rifle Ammo")]
    public int arAmmo;
    public int rifleAmmo;
    public int magnumAmmo;
    public int explosiveAmmo;
    [Space]

    [Header("Player Info")]
    public int health;
    public int maxHealth;
    public int XP;
    public int maxXP;
    public int damage;
    public int defense;
    public int curLevel;
    public int statPoints;
    public float speed;
    public float lightRadius;
    public float curWeight;
    public float maxWeight;



    //player Stats
    [Header("Player Stats")]
    public int constitution;
    public int fortitude;
    public int dexterity;
    public int strength;
    public int intelligence;
    public int charisma;
    public int agility;
    public int luck;
    public float perception;

}
