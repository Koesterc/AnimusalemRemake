using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedArmor : MonoBehaviour
{
    BaseArmor dropArmor = new BaseArmor();
    public void DropArmor(BaseArmor myArmor)
    {
        dropArmor = myArmor;
        gameObject.GetComponent<ItemDisplay>().myText.text = dropArmor.ArmorTypes.ToString()+" Armor";
        //subtract player's weight
    }

}
