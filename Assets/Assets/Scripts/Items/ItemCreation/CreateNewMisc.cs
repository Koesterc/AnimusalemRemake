using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewMisc : MonoBehaviour
{
    private BaseMisc newMisc;




    public void CreateMisc()
    {
        newMisc = new BaseMisc();
        newMisc.ItemID = Random.Range(0, 10000);
        ChooseMiscType();
    }

    private void ChooseMiscType()
    {
        int temp = Random.Range(0, 7);

        switch (temp)
        {
            default:
                newMisc.MiscTypes = BaseMisc.MiscType.SmallAid;
                //assigning the name
                newMisc.ItemName = "Small Aid";
                newMisc.ItemDesc = "A small bottle of medical ointment. There's just enough to treat a minor wound.";
                newMisc.Weight = .2f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/SmallAid");
                break;
            case 1:
                newMisc.MiscTypes = BaseMisc.MiscType.MediumAid;
                //assigning the name
                newMisc.ItemName = "Medium Aid";
                newMisc.ItemDesc = "A well supplied kit with various items essential to treat moderate injuries.";
                newMisc.Weight = .4f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/MedAid");
                break;
            case 2:
                newMisc.MiscTypes = BaseMisc.MiscType.LargeAid;
                //assigning the name
                newMisc.ItemName = "Large Aid";
                newMisc.ItemDesc = "An imeasurable supply of medical equipment used to treat serious lacerations.";
                newMisc.Weight = .6f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/LargeAid");
                break;
            case 3:
                newMisc.MiscTypes = BaseMisc.MiscType.PainKiller;
                //assigning the name
                newMisc.ItemName = "Pain Killer";
                newMisc.ItemDesc = "Reduces the amount of injury one takes while in battle. The effects last only for a short duration.";
                newMisc.Weight = .2f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/PainKillers");
                break;
            case 4:
                newMisc.MiscTypes = BaseMisc.MiscType.HolyWater;
                //assigning the name
                newMisc.ItemName = "Holy Water";
                newMisc.ItemDesc = "A small portion of blessed water. Mainly, it can be used to avoid unwanted attention.";
                newMisc.Weight = .55f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/HolyWater");
                break;
            case 5:
                newMisc.MiscTypes = BaseMisc.MiscType.DreamCatcher;
                //assigning the name
                newMisc.ItemName = "Dream Catcher";
                newMisc.ItemDesc = "Although it is typically used to avoid bad dreams, this item can be used in battle to avoid a bad situation.";
                newMisc.Weight = .55f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/DreamCatcher");
                break;
            case 6:
                newMisc.MiscTypes = BaseMisc.MiscType.OldKey;
                //assigning the name
                newMisc.ItemName = "Old Key";
                newMisc.ItemDesc = "It seems as though its purpose serves to unlock old chests, of which many contain items.";
                newMisc.Weight = .1f;
                newMisc.Icon = Resources.Load<Sprite>("Icons/Miscs/OldKey");
                break;
        }
    }

    public BaseMisc NewMisc
    {
        get { return newMisc; }
        set { newMisc = value; }
    }
}
