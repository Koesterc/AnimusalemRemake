using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    BaseWeapon dropWeapon = new BaseWeapon();
    public void DropWeapon(BaseWeapon myWeapon)
    {
        dropWeapon = myWeapon;
        gameObject.GetComponent<ItemDisplay>().myText.text = dropWeapon.WeaponTypes.ToString();
        //subtract player's weight
    }
    public BaseWeapon WeaponStats
    {
        get { return dropWeapon; }
    }
}
