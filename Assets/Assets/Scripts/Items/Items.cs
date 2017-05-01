using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    void Start()
    {
        Item item = new Item()
        {
            itemID = Random.Range(0, 1000),
            enhancedDamage = 30,
            coldDamage = 30,
            coldRes = 30,
            fireDamage = 30,
            fireRes = 30,
            poisonDamage = 30,
            poisonRes = 30
        };

        Dictionary<int, Item> newItem = new Dictionary<int, Item>();
        newItem.Add(item.itemID, item);
        print (newItem);
    }


}
