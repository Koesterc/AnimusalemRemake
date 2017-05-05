using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedMisc : MonoBehaviour
{
    BaseMisc dropMisc = new BaseMisc();
    public void DropMisc(BaseMisc myMisc)
    {
        dropMisc = myMisc;
        gameObject.GetComponent<ItemDisplay>().myText.text = dropMisc.MiscTypes.ToString();
        //subtract player's weight
    }
    public BaseMisc MiscStats
    {
        get { return dropMisc; }
    }
}
