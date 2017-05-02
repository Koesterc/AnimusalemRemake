using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : BaseStatItem
{
    public enum WeaponType
    {
        Handgun,
        Rifle,
        Shotgun,
        Machinegun,
        AssaultRifle,
        Magnum,
        Explosive
    }
    private WeaponType weaponTypes;


    //attributes
    int damage;
    float fireRate;
    int capacity;
    float reload;
    float accuracy;
    float criticalDamage;
    float criticalChance;
    //upgrades
    int upDamage;
    float upFireRate;
    int upCapacity;
    float upReload;
    float upAccuracy;
    float upCriticalDamage;
    float upCriticalChance;
    //current Upgrades
    int damageLvl;
    int fireRateLvl;
    int reloadLvl;
    int criticalChanceLvl;
    int criticalDamageLvl;
    int accuracyLvl;
    int capacityLvl;


    //getters setters
    public WeaponType WeaponTypes
    {
        get { return weaponTypes; }
        set { weaponTypes = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float Firerate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }
    public float Reload
    {
        get { return reload; }
        set { reload = value; }
    }
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }
    public float Accuracy
    {
        get { return accuracy; }
        set { accuracy = value; }
    }
    public float CriticalChance
    {
        get { return criticalChance; }
        set { criticalChance = value; }
    }
    public float CriticalDamage
    {
        get { return CriticalDamage; }
        set { CriticalDamage = value; }
    }
    //upgrades
    public int UpDamage
    {
        get { return upDamage; }
        set { upDamage = value; }
    }
    public float UpFireRate
    {
        get { return upFireRate; }
        set { upFireRate = value; }
    }
    public float UpReload
    {
        get { return upReload; }
        set { upReload = value; }
    }
    public float UpAccuracy
    {
        get { return upAccuracy; }
        set { upAccuracy = value; }
    }
    public float UpCriticalChance
    {
        get { return upCriticalChance; }
        set { upCriticalChance = value; }
    }
    public float UpCriticalDamage
    {
        get { return upCriticalDamage; }
        set { upCriticalDamage = value; }
    }
    public int UpCapacity
    {
        get { return upCapacity; }
        set { upCapacity = value; }
    }
    //current level of upgrades
    public int CapacityLvl
    {
        get { return capacityLvl; }
        set { capacityLvl = value; }
    }
    public int ReloadLvl
    {
        get { return reloadLvl; }
        set { reloadLvl = value; }
    }
    public int DamageLvl
    {
        get { return damageLvl; }
        set { damageLvl = value; }
    }
    public int FireRateLvl
    {
        get { return fireRateLvl; }
        set { fireRateLvl = value; }
    }
    public int AccuracyLvl
    {
        get { return accuracyLvl; }
        set { accuracyLvl = value; }
    }
    public int CriticalChanceLvl
    {
        get { return criticalChanceLvl; }
        set { criticalChanceLvl = value; }
    }
    public int CriticalDamageLvl
    {
        get { return criticalDamageLvl; }
        set { criticalDamageLvl = value; }
    }
}
