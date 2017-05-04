using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    //player Info
    [Header("Items")]
    public static int money;
    [Tooltip("Handgun Ammo")]
    public static int hgAmmo;
    [Tooltip("Shotgun Ammo")]
    public static int sgAmmo;
    [Tooltip("MachineGun Ammo")]
    public static int mgAmmo;
    [Tooltip("Assault Rifle Ammo")]
    public static int arAmmo;
    public static int rifleAmmo;
    public static int magnumAmmo;
    public static int explosiveAmmo;
    [Space]

    [Header("Player Info")]
    public static int health;
    public static int maxHealth;
    public static int XP;
    public static int maxXP;
    public static int damage;
    public static int defense;
    public static int curLevel;
    public static int statPoints;
    public static float speed;
    public static float lightRadius;
    public static float curWeight;
    public static float maxWeight;



    //player Stats
    [Header("Player Stats")]
    public static int constitution;
    public static int fortitude;
    public static int dexterity;
    public static int strength;
    public static int intelligence;
    public static int charisma;
    public static int agility;
    public static int luck;
    public static float perception;

}
