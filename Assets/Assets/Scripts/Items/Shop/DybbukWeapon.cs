using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DybbukWeapon : MonoBehaviour
{
    BaseWeapon shopWeapon = new BaseWeapon();

    public void TransferData(BaseWeapon weapon)
    {
        shopWeapon = weapon;
    }

    public BaseWeapon ShopWeapon
    {
        get { return shopWeapon; }
        set { shopWeapon = value; }
    }

    public void OnSelect()
    {
        UI.sellContent.transform.localPosition = new Vector3(UI.sellContent.transform.localPosition.x, -transform.localPosition.y, UI.sellContent.transform.localPosition.z);
        InventorySounds.select.Play();
    }
}

