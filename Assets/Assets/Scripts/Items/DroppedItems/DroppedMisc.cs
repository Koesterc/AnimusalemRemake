using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedMisc : MonoBehaviour
{
    public GameObject inventoryMiscPrefab;
    BaseMisc dropMisc = new BaseMisc();
    public void DropMisc(BaseMisc myMisc)
    {
        dropMisc = myMisc;
        gameObject.GetComponent<ItemDisplay>().myText.text = dropMisc.MiscTypes.ToString();
        switch (dropMisc.MiscTypes)
        {
            case BaseMisc.MiscType.HandgunAmmo:
                PlayerStats.hgAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.ShotgunShells:
                PlayerStats.sgAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.RifleAmmo:
                PlayerStats.rifleAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.MachinegunAmmo:
                PlayerStats.mgAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.AssaultRifleAmmo:
                PlayerStats.arAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.MagnumAmmo:
                PlayerStats.magnumAmmo -= dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.ExplosiveRounds:
                PlayerStats.explosiveAmmo -= dropMisc.Quanntity;
                break;
        }
        //subtract player's weight
    }
    public BaseMisc MiscStats
    {
        get { return dropMisc; }
    }

    public void PickedUp()
    {
        GameObject clone;
        clone = Instantiate(inventoryMiscPrefab, Inventory.inventoryContent.transform.position, transform.rotation) as GameObject;
        clone.transform.SetParent(Inventory.inventoryContent.transform, true);
        clone.transform.localScale = new Vector3(1, 1, 1);
        clone.GetComponent<InventoryMisc>().pickedUpMisc(dropMisc);
        switch (dropMisc.MiscTypes)
        {
            case BaseMisc.MiscType.HandgunAmmo:
                PlayerStats.hgAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.ShotgunShells:
                PlayerStats.sgAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.RifleAmmo:
                PlayerStats.rifleAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.MachinegunAmmo:
                PlayerStats.mgAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.AssaultRifleAmmo:
                PlayerStats.arAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.MagnumAmmo:
                PlayerStats.magnumAmmo += dropMisc.Quanntity;
                break;
            case BaseMisc.MiscType.ExplosiveRounds:
                PlayerStats.explosiveAmmo += dropMisc.Quanntity;
                break;
        }
        InventoryList.itemList.Add(clone.gameObject);
        Destroy(gameObject);
    }

}
