using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DybbukWeapon : MonoBehaviour
{
    BaseWeapon shopWeapon = new BaseWeapon();

    // Use this for initialization
    void Start()
    {
        //if (gameObject.GetComponent<CreateNewWeapon>())
        //{
        //    CreateNewWeapon c = gameObject.GetComponent<CreateNewWeapon>();
        //    shopWeapon = c.NewWeapon;
        //    Destroy(c);
        //    transform.FindChild("Value").GetComponent<Text>().text = "$" + shopWeapon.SellValue.ToString();
        //    print (shopWeapon.SellValue);
        //}
    }

    public void TransferData(BaseWeapon weapon)
    {
        shopWeapon = weapon;
    }

    public BaseWeapon ShopWeapon
    {
        get { return shopWeapon; }
        set { shopWeapon = value; }
    }
}

