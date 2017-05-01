using UnityEngine;

public class Weapons : Item
{


    public string weaponName;
    public WeaponType weaponType;

    public int dmg = 0;
    public int reload = 0;
    public int fireRate = 0;
    public int capacity = 0;
    public int accuracy = 0;
    public int criticlChance = 0;
    public int criticalDamage = 0;

    public Weapons()
    {
        //weaponType = WeaponType.Handgun;
        //dmg = 0;
        //reload = 0;
        //fireRate = 0;
        //capacity = 0;
        //accuracy = 0;
        //criticlChance = 0;
        //criticalDamage = 0;
    }
    public Weapons(int _dmg, float _reload, float _fireRate, int _capacity, float _accuracy, float _criticalChance, float _criticalDamage, float _weight)
    {
        _dmg = 0;
        _reload = 0;
        _fireRate = 0;
        _capacity = 0;
        _accuracy = 0;
        _criticalChance = 0;
        _criticalDamage = 0;
        _weight = 0;
    }
    //public int Damge
    //{
    //    get { return dmg; }
    //    set { dmg = value; }
    //}

    public void CreateWeapon()
    {
        BaseWeapon newWeapon = new BaseWeapon();
        weaponName = newWeapon.HGNames[Random.Range(0, newWeapon.HGNames.Length)];
        newWeapon.itemID = Random.Range(0, 1000);
        newWeapon.levelRestriction = Random.Range(1, 50);
        newWeapon.dmg = Random.Range(10* newWeapon.levelRestriction, 20 * newWeapon.levelRestriction);
    }
}

public enum WeaponType { Handgun, Rifle, Machinegun, Shotgun, Magnum, Explosive };
