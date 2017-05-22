using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DybbukAmmo : MonoBehaviour {

    BaseAmmo shopAmmo = new BaseAmmo();

    public void TransferData(BaseAmmo ammo)
    {
        shopAmmo = ammo;
    }

    public BaseAmmo ShopAmmo
    {
        get { return shopAmmo; }
        set { shopAmmo = value; }
    }

    public void OnSelect()
    {
        UI.sellContent.transform.localPosition = new Vector3(UI.sellContent.transform.localPosition.x, -transform.localPosition.y, UI.sellContent.transform.localPosition.z);
        InventorySounds.select.Play();
    }

    private void OnEnable()
    {
        switch (shopAmmo.AmmoTypes)
        {
            case BaseAmmo.AmmoType.HandgunAmmo:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.hgAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.ShotgunShells:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.sgAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.MachinegunAmmo:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.mgAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.AssaultRifleAmmo:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.arAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.RifleAmmo:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.rifleAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.MagnumAmmo:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.magnumAmmo.ToString();
                break;
            case BaseAmmo.AmmoType.ExplosiveRounds:
                transform.FindChild("Level").GetComponent<Text>().text = "Quantity: " + PlayerStats.explosiveAmmo.ToString();
                break;
        }
        transform.FindChild("Value").GetComponent<Text>().text = "$" + GetComponent<DybbukAmmo>().ShopAmmo.SellValue.ToString();
    }
}
