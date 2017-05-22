using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DybbukArmor : MonoBehaviour
{

    BaseArmor shopArmor = new BaseArmor();

    public void TransferData(BaseArmor armor)
    {
        shopArmor = armor;
    }

    public BaseArmor ShopArmor
    {
        get { return shopArmor; }
        set { shopArmor = value; }
    }

    public void OnSelect()
    {
        UI.sellContent.transform.localPosition = new Vector3(UI.sellContent.transform.localPosition.x, -transform.localPosition.y, UI.sellContent.transform.localPosition.z);
        InventorySounds.select.Play();
    }
}
