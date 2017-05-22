using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DybbukMisc : MonoBehaviour {


    BaseMisc shopMisc = new BaseMisc();

    public void TransferData(BaseMisc misc)
    {
        shopMisc = misc;
    }

    public BaseMisc ShopMisc
    {
        get { return shopMisc; }
        set { shopMisc = value; }
    }

    public void OnSelect()
    {
        UI.sellContent.transform.localPosition = new Vector3(UI.sellContent.transform.localPosition.x, -transform.localPosition.y, UI.sellContent.transform.localPosition.z);
        InventorySounds.select.Play();
    }
}
