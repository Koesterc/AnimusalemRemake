using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public List<Gun> weapon;
    public int curWeapon = 0;

    void OnEnable()
    {
        Transform guns = gameObject.transform.Find("Guns");
        foreach (Transform gun in guns)
        {
        //    Debug.Log(gun.transform.Find("MyScript").GetComponent<Gun>());
            weapon.Add(gun.GetComponent<WeaponPerks>().perks);        // Adds x to the end of the list
        }
    }

    void Update()
    {
        //switching weapon left
        if (Input.GetKeyDown("1"))
        {
            if (curWeapon > 0)
                curWeapon -= 1;
            else
                curWeapon = weapon.Count - 1;

            weapon[curWeapon] = gameObject.transform.Find("Guns/Gun").GetComponent<WeaponPerks>().perks;
            //print(weapon[curWeapon].dmg);
        }
        //switching weapon right
        if (Input.GetKeyDown("2"))
        {
            if (curWeapon < weapon.Count - 1)
                curWeapon += 1;
            else
                curWeapon = 0;

            weapon[curWeapon] = gameObject.transform.Find("Guns/Gun").GetComponent<WeaponPerks>().perks;
      //      print(weapon[curWeapon].dmg);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //fires off function from the child's script (Folder scrits/items/weapons) 
            weapon[curWeapon].Fire();
        }
    }

}
