using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    //player Info
    [Header("Items")]
    public static int money;
    [Space]
    [Tooltip("Handgun Ammo")]
    public static int hgAmmo = 25;
    [Tooltip("Shotgun Ammo")]
    public static int sgAmmo = 15;
    [Tooltip("MachineGun Ammo")]
    public static int mgAmmo = 35;
    [Tooltip("Assault Rifle Ammo")]
    public static int arAmmo = 45;
    public static int rifleAmmo = 35;
    public static int magnumAmmo = 25;
    public static int explosiveAmmo = 15;
    //ammo weight
    [Space]
    [Tooltip("Handgun Ammo")]
    public static float hgAmmoWeight = .04f;
    [Tooltip("Shotgun Ammo")]
    public static float sgAmmoWeight = .12f;
    [Tooltip("MachineGun Ammo")]
    public static float mgAmmoWeight = .02f;
    [Tooltip("Assault Rifle Ammo")]
    public static float arAmmoWeight = .06f;
    public static float rifleAmmoWeight = .08f;
    public static float magnumAmmoWeight = .15f;
    public static float explosiveAmmoWeight = 1.2f;

    [Header("Player Info")]
    public static int health = 100;
    public static int maxHealth = 100;
    public static int XP = 0;
    public static int maxXP = 250;
    public static int damage;
    public static int defense;
    public static int curLevel =1;
    public static int statPoints;
    public static float speed = 3f;
    public static float lightRadius;
    public static float curWeight = 0f;
    public static float maxWeight = 6f;
    //referringthe the melee/knife attack
    public static int attackSpeed;
    public static int attackRange;
    public static int meleeDamage;

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
    //remaining stat point
    public static float statPoint;

}
