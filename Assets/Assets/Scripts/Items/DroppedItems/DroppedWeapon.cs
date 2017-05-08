using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    public GameObject inventoryWeaponPrefab;
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

    public void PickedUp()
    {
        GameObject clone;
        clone = Instantiate(inventoryWeaponPrefab, Inventory.inventoryContent.transform.position, transform.rotation) as GameObject;
        clone.transform.SetParent(Inventory.inventoryContent.transform, true);
        clone.transform.localScale = new Vector3(1, 1, 1);
        clone.GetComponent<CreateNewWeapon>().pickedUpWeapon(dropWeapon);
        Destroy(gameObject);
    }
}
